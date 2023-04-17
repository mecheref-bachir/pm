
using Microsoft.AspNetCore.Mvc;
using project.Models.ProductModels.Dto;

namespace project.Controllers.ShoppingCartControllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(ProductModel model)
        {

            return RedirectToAction("Index", "Home");
        }
    }
}
