using Microsoft.EntityFrameworkCore;
using project.Repositories.BankSystem.BankSystemModels;

namespace project.Models.ProductModels.Domain
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base (options)
        {
            
        }

        public DbSet<Product> Products { get; set;}
        public DbSet<MasterAccounts> MasterAccounts { get; set; }
        public DbSet<MasterTransactions> MasterTransactions{ get; set; }
        
    }
}
