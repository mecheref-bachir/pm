using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace project.Controllers.RegistrationControllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        public IActionResult Display()
        {
            return View();
        }
    }
}
