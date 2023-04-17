
using Microsoft.AspNetCore.Mvc;
using project.Repositories.Abstruct;
using System.Diagnostics;
using project.Models;
using project.Models.ProductModels.Dto;


namespace project.Controllers.RegistrationControllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService productService;
     

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {   
            this.productService = productService;
            _logger = logger;
           
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //get all products for home page
      
        public IActionResult Index(int PageNumber=1, string operation="default")
        {
         
            return  View(productService.GetAllProducts(PageNumber,operation));

        }
    }
}