using Microsoft.EntityFrameworkCore;

namespace project.Models.ShoppingCartModels.Domain
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Product> Products { get; set;}
    }
}
