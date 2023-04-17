

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using project.Models.RegistrationModels.Dto;
using project.Models.RegistrationModels.Domain;
using project.Repositories.Abstruct;
using project.Models.ReportModels;
using project.Models;
using project.Models.PaymentModels;

namespace project.Repositories.Impl
{
    public class UserAuthenticationServiceImpl : UserAuthenticationService

    {
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly SmtpService smtpService;

        private readonly DatabaseContext databaseContext;
        private readonly PaymentService paymentService;


        public UserAuthenticationServiceImpl(PaymentService paymentService, DatabaseContext databaseContext,SmtpService smtpService,SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.databaseContext = databaseContext;
            this.smtpService = smtpService;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.paymentService= paymentService;
           
        }

        public async Task<Status> ApproveUser(string UserName)
        {

            var user = await userManager.FindByNameAsync(UserName);
            user.isApproved = true;
            await userManager.UpdateAsync(user);
            smtpService.SendEmailTo(user.Email, "Your Application on ShoppingCart System", "Congratulations " + user.Name + " ,your account has been approved ");
            var status = new Status();
            status.StatusCode = 0;
            status.Message = "Invalid userNmame";
            return status;
        }

        public async Task<Status> DeleteUserAsync(string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);
            await userManager.DeleteAsync(user);
            var status = new Status();
            status.StatusCode = 0;
            status.Message = "User deleted successfully";
            return status;
        }

        public ManageUsersPageModel GetAllNonApprovedUsers(int PageNumber, string Operation)
        {
            int temp = PageNumber;
            int Total = databaseContext.Users.Where(user => user.isApproved == false).Count();
            int PageSize = 6;
            if (Operation.Equals("previouse"))
            {
                PageNumber--;
            }
            else if (Operation.Equals("next"))
            {
                PageNumber++;
            }

            int NumberOfPages = (int)Math.Ceiling((decimal)Total / PageSize);

            if (PageNumber > NumberOfPages || PageNumber <= 0)
            {
                PageNumber = temp;
            }

            List<ApplicationUserDto> list = databaseContext.Users.Where(user=>user.isApproved==false).ToList().Skip((PageNumber - 1) * PageSize).Take(PageSize).Select(user => {

                ApplicationUserDto model = new ApplicationUserDto();
                model.UserName = user.UserName;
                model.Name = user.Name;
                model.Email = user.Email;
                model.Role=userManager.GetRolesAsync(user).Result.FirstOrDefault();

                return model;

            }).ToList();

            ManageUsersPageModel model = new ManageUsersPageModel();
            Page page = new Page();
            page.PageNumber = PageNumber;
            model.Page = page;
            model.NonApprovedUsersList = list;
            return model;

        }

        public async Task<Status> LoginAsync(LoginModel model)
        {

            var status = new Status();
            //check user name
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid userNmame";
                return status;
            }
            // check if user isApproved
            if (!user.isApproved)
            {
                status.StatusCode = 0;
                status.Message = "Account not approved yet";
                return status;

            }
            // check password

            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
               };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

              

                status.StatusCode = 1;
                status.Message = "Loged in successfully";
                return status;

            }
            else if (signInResult.IsLockedOut)
            {

                status.StatusCode = 0;
                status.Message = "user Locked out";
                return status;


            }
            else
            {

                status.StatusCode = 0;
                status.Message = "error on login";
                return status;

            }
        }


        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();

        }

        public async Task<Status> RegistrationAsync(Registration RegistrationModel)
        {

            var status = new Status();
            var userExists = await userManager.FindByNameAsync(RegistrationModel.UserName);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already Exists";
                return status;

            }

            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = RegistrationModel.UserName,
                Email = RegistrationModel.Email,
                UserName = RegistrationModel.UserName,
                EmailConfirmed = true,
                isApproved = false,

            };

            var result = await userManager.CreateAsync(user, RegistrationModel.Password);

            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "failed to create User";
                return status;
            }
            //role management

            if (!await roleManager.RoleExistsAsync(RegistrationModel.Role))

                await roleManager.CreateAsync(new IdentityRole(RegistrationModel.Role));


            if (await roleManager.RoleExistsAsync(RegistrationModel.Role))
            {
                await userManager.AddToRoleAsync(user, RegistrationModel.Role);
            }

            // todo: call the service payement
            if (RegistrationModel.Role == "vendor")
            {
                PaymentData data = new PaymentData();
                    data.Name = RegistrationModel.Name;
                    data.ExpirationDate = (DateTime)RegistrationModel.ExpirationDate;
                    data.CardNumber = (long)RegistrationModel.CardNumber;
                    data.CVV = (int)RegistrationModel.CVV;
                    data.RecieverAccountNumber = 4444444444444444;
                    data.RecieverPayementType = PaymentType.MASTER;
                  
                
                if (RegistrationModel.PaymentMethod.Equals("visa"))
                {
                    data.PaymentMethod = PaymentType.VISA;

                }
                else
                {
                    data.PaymentMethod = PaymentType.MASTER;
                }

               Status s =  paymentService.VendorPayment(data);

                if(s.StatusCode == 0)
                {

                    // role back registration if payement failed
                    await DeleteUserAsync(RegistrationModel.UserName);
                    s.Message = "Registration Failed , can not proceed with payment";
                    return s;
                }
                else
                {
                  smtpService.SendEmailTo(user.Email, "Your Application on ShopingCart System as a vendor", "Hi " + user.Name + " Thank you for signing,your payment for 2000$ is confirmed  you account will be approved as soon as possible ");
                    s.Message = "Registration succeed";
                    return s;
                }
            
           

            }

        smtpService.SendEmailTo(user.Email, "Your Application on ShopingCart System", "Hi " + user.Name +" Thank you for signing, you account will be approved as soon as possible ");

            status.StatusCode = 1;
            status.Message = "User Registred succefully";
            return status;
        }
    }
}
