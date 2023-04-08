using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using project.Models.RegistrationModels.Domain;
using project.Models.ShoppingCartModels.Dto;
using project.Repositories.Abstruct;

namespace project.Controllers.RegistrationControllers
{
    [Authorize(Roles = "vendor")]
    public class VendorController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;
        private readonly ProductService ProductService;


        public VendorController(ProductService ProductService, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {    this.userManager= userManager;
            this.ProductService = ProductService;
        }
        public IActionResult MyStore()
        {
            return View();
        }

        public async Task<IActionResult> AddProduct(ProductModel model)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var result =  await ProductService.SaveProduct(model,userId);
            TempData["msg"] = result.Message;
            return RedirectToAction("Index", "Home");
           
        }
    }
}
