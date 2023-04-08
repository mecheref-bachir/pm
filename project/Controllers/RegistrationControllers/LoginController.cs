using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Models.RegistrationModels.Dto;
using project.Repositories.Abstruct;

namespace project.Controllers.RegistrationControllers
{
    public class LoginController : Controller
    {

        private readonly UserAuthenticationService userAuthenticationService;
        public LoginController(UserAuthenticationService userAuthenticationService)
        {
            this.userAuthenticationService = userAuthenticationService;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Registration(Registration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await userAuthenticationService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userAuthenticationService.LoginAsync(model);
            if (result.StatusCode == 1)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await userAuthenticationService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }



        public async Task<IActionResult> Reg()
        {
            var model = new Registration()
            {
                UserName = "aaa",
                Name = "bachir1",
                Email = "bachir1@gmail.com",
                Password = "Bachir@12345#",
            };
            model.Role = "admin";
            var result = await userAuthenticationService.RegistrationAsync(model);
            return Ok(result);
        }

    }
}
