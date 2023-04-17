
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Models.ProductModels.Dto;
using project.Models.RegistrationModels.Domain;
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
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel model)
        {
            IFormFile file = model.Image;
          
            var userId = userManager.GetUserId(HttpContext.User);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages");
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            string ImageName= Path.GetFileName(model.Image.FileName);
            var result =  await ProductService.SaveProduct(model,userId,ImageName);
            TempData["msg"] = result.Message;
            return RedirectToAction("MyStore");
           
        }
    }
}
