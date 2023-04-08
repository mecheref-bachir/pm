using project.Models.ShoppingCartModels.Dto;

namespace project.Repositories.Abstruct
{
    public interface ProductService
    {

        Task<Status> SaveProduct(ProductModel model,string id);
    }
}
