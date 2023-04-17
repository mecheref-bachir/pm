using project.Models.ProductModels.Dto;
using project.Models.ReportModels;

namespace project.Repositories.Abstruct
{
    public interface ProductService
    {

        Task<Status> SaveProduct(ProductModel model,string id,string ImageName);
        MainPageModel GetAllProducts(int PageNumber,string Action);

        ManageProductsPageModel getAllNonApprovedProducts(int PageNumber,string operation);

        Status AproveProduct(int ProductId);

        Status DeleteProduct(int ProductId);
        
        

    }
}
