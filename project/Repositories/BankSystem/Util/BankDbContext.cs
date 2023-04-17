using Microsoft.EntityFrameworkCore;
using project.Repositories.BankSystem.BankSystemModels;

namespace project.Repositories.BankSystem.Util
{
    public class BankDbContext : DbContext
    {
        public DbSet<MasterAccounts> Accounts { get; set; }
        public DbSet<MasterTransactions> Transactions { get; set; }
        public BankDbContext(DbContextOptions<BankDbContext> options) : base (options)
        {

        }
    }
}
