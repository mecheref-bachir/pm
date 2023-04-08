

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using project.Models.RegistrationModels.Dto;
using project.Models.RegistrationModels.Domain;
using project.Repositories.Abstruct;
namespace project.Repositories.Impl
{
    public class UserAuthenticationServiceImpl : UserAuthenticationService

    {
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly RoleManager<IdentityRole> roleManager;


        public UserAuthenticationServiceImpl(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
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

            status.StatusCode = 1;
            status.Message = "User Registred succefully";
            return status;
        }
    }
}
