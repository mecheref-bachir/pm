using project.Repositories.Abstruct;
using project.Models;
using project.Models.ReportModels;
using project.Models.ProductModels.Dto;
using project.Models.ProductModels.Domain;

namespace project.Repositories.Impl
{
    public class ProductServiceImpl : ProductService
    {
       
        private readonly MyDbContext context;
 
        public ProductServiceImpl(MyDbContext context)
        {
            this.context = context;
               
        }

        public  Status AproveProduct(int Id)
        {
            Product product = context.Products.Where(p=>p.PrdoductId==Id).First();
            product.isAproved = true;
            context.SaveChanges();
            Status status = new();
            status.StatusCode = 1;
            status.Message = "Product approved";
            return status;
        }

        public Status DeleteProduct(int ProductId)
        {
            Product product = context.Products.Where(p=>p.PrdoductId == ProductId).First();
            context.Products.Remove(product);
            context.SaveChanges() ;
            Status status = new();
            status.StatusCode = 1;
            status.Message="Product removed successfully";
            return status;
        }
        public ManageProductsPageModel getAllNonApprovedProducts(int PageNumber, string Operation)
        {
            int temp = PageNumber;
            int Total = context.Products.Where(p=>p.isAproved == false).ToList().Count();
            int PageSize =6;
            if (Operation.Equals("previouse"))
            {
                PageNumber--;
            }
            else if (Operation.Equals("next"))
            {
                PageNumber++;
            }

            int NumberOfPages = (int)Math.Ceiling((decimal)Total / PageSize);

            if (PageNumber > NumberOfPages || PageNumber <= 0)
            {
                PageNumber = temp;
            }

            List<ProductModelReport> list = context.Products.Where(product=> product.isAproved==false).ToList().Skip((PageNumber - 1) * PageSize).Take(PageSize).Select(Product => {
             
                ProductModelReport model = new ProductModelReport();
               
                model.Price = Product.Price;
                model.PrdoductId = Product.PrdoductId;
                model.Name = Product.Name;
                model.ProductCategory = Product.ProductCategory;

                return model;

            }).ToList();

            ManageProductsPageModel model = new ManageProductsPageModel();
            Page page = new Page();
            page.PageNumber = PageNumber;
            model.Page = page;
            model.NonApprovedProductList = list;
            return model;
        }

        // get all product
        public MainPageModel GetAllProducts(int PageNumber, string Operation)
        {
            int temp = PageNumber;
            int Total = context.Products.Where(product => product.isAproved == true).ToList().Count();
            int PageSize = 8;
             if (Operation.Equals("previouse"))
            {
                PageNumber--;
            }
            else if (Operation.Equals("next"))
            {
                PageNumber++;
            }
            
             int NumberOfPages = (int)Math.Ceiling((decimal)Total / PageSize);

            if(PageNumber > NumberOfPages || PageNumber <= 0)
            {
                PageNumber = temp;
            }
      
                List<ProductModel> list = context.Products.Where(product=>product.isAproved==true).ToList().Skip((PageNumber-1)*PageSize).Take(PageSize).Select(Product => {
                string ImageUrl = Product.ImageUrl;
                string image = Path.Combine("~/productImages/", ImageUrl);
                ProductModel model =  new ProductModel();
                model.ImageUrl = image;
                model.Price = Product.Price;
                model.PrdoductId = Product.PrdoductId;
                model.Name = Product.Name;

                return model;
            
            }).ToList();

            MainPageModel model = new MainPageModel();
            Page page = new Page();
            page.PageNumber = PageNumber;
            model.page = page;
            model.ProductList = list;
            return model;

        }

        // save a product 
        public async Task<Status> SaveProduct(ProductModel model,string id, string ImageName)
        {
            Product product = new Product();
            product.ImageUrl = ImageName;
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
