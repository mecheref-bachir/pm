using Microsoft.EntityFrameworkCore;
using project.Repositories.BankSystem.BankSystemModels;

namespace project.Repositories.BankSystem.Util
{
    public class MyBankDbContext : DbContext 
    {

        public DbSet<MasterAccounts> MasterAccounts { get; set; }
        public DbSet<MasterTransactions> MasterTransactions { get; set; }

        public DbSet<VisaAcounts> VisaAccounts { get; set; }
        public DbSet<VisaTransactions> VisaTransactions { get; set; }
        public MyBankDbContext(DbContextOptions<MyBankDbContext> options) : base(options)
        {

        }
    }
}
