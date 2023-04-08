
using project.Models.ShoppingCartModels.Dto;
using Microsoft.AspNetCore.Identity;
using project.Models.RegistrationModels.Domain;
using project.Models.ShoppingCartModels.Domain;
using project.Repositories.Abstruct;


namespace project.Repositories.Impl
{
    public class ProductServiceImpl : ProductService
    {
       
        private readonly MyDbContext context;
        public ProductServiceImpl(MyDbContext context)
        {
            this.context = context;
          

        }
        public async Task<Status> SaveProduct(ProductModel model,string id)
        {


          


            Product product = new Product();
            product.vendor = id;
            product.Name = model.Name;  
            product.ProductCategory=model.ProductCategory;  
            product.Price= model.Price;

            
            
            context.Add(product);

            Status status = new Status();
            status.StatusCode = 0;
            status.Message = "Product saved";
             context.SaveChanges();
            return status;

        }
    }
}
