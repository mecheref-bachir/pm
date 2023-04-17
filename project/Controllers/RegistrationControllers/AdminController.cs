using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Repositories.Abstruct;
using System.Diagnostics;

namespace project.Controllers.RegistrationControllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ReportService reportService;
        private readonly UserAuthenticationService userAuthenticationService;
        private readonly ProductService productService;
        public AdminController(ReportService reportService, UserAuthenticationService userAuthenticationService, ProductService productService)
        {
            this.reportService = reportService;
            this.userAuthenticationService = userAuthenticationService;
            this.productService=productService;
        }


        // get all non approved Users
        [HttpGet]
        public IActionResult ManageUsers(int PageNumber = 1, string operation = "default")
        {
            return View(reportService.GetAllNonAprovedUsers( PageNumber , operation));
        }

        // approve user 
        public  async Task<IActionResult> ApprouveUser(string UserName)
                
        {
             await  userAuthenticationService.ApproveUser(UserName);
            return RedirectToAction(nameof(ManageUsers));
        }

        // delete a Non Approved User user
        public async Task<IActionResult> DeleteUser(string UserName)
        {
            await   userAuthenticationService.DeleteUserAsync(UserName);
            return RedirectToAction(nameof(ManageUsers));
        }
        // get all non approved products 
        public IActionResult ManageProducts(int PageNumber = 1, string Operation= "default")
        {
            return View(reportService.GetAllNonAprovedProducts(PageNumber,Operation));
        }



        //delete product
        public IActionResult DeleteProduct(int ProductId) {
            productService.DeleteProduct(ProductId);
            return RedirectToAction(nameof(ManageProducts));
        }

        //Approve a product 
        public IActionResult ApproveProduct(int ProductId)
        {
            productService.AproveProduct(ProductId);
            return RedirectToAction(nameof(ManageProducts));
        }



        // Admin Statistics
        public IActionResult Statistics()
        {
            return View();
        }
    }
}
