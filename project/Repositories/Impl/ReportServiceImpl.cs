
using project.Models.ReportModels;
using project.Repositories.Abstruct;
namespace project.Repositories.Impl
{
    public class ReportServiceImpl : ReportService

     
        
    {
        private readonly ProductService _ProductService;
        private readonly UserAuthenticationService _UserAuthenticationService;
        public ReportServiceImpl(ProductService productService, UserAuthenticationService userAuthenticationService)
        {
           this._ProductService = productService; 
           this._UserAuthenticationService = userAuthenticationService; 
        }
        public ManageProductsPageModel GetAllNonAprovedProducts(int PageNumber,string Operation)
        {
            return _ProductService.getAllNonApprovedProducts(PageNumber, Operation);
        }

        public ManageUsersPageModel GetAllNonAprovedUsers(int PageNumber , string operation )
        {
            ManageUsersPageModel model = _UserAuthenticationService.GetAllNonApprovedUsers( PageNumber, operation);
            return model;
        }
    }
}
