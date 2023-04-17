using Microsoft.EntityFrameworkCore;
using project.Repositories.BankSystem.BankSystemModels;

namespace project.Repositories.BankSystem.Util
{
    public class BankingDbContext :DbContext
    {
        public DbSet<MasterAccounts> Accounts { get; set; }
        public DbSet<MasterTransactions> Transactions { get; set; }
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {

        }

    }
}
