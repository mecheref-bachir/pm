using project.Repositories.BankSystem.Util;
using System.ComponentModel.DataAnnotations;

namespace project.Repositories.BankSystem.BankSystemModels
{
    public class MasterAccounts
    {
        [Key]
        public long CartNumber { get; set; }
        public string NameOnCard { get; set; }

        public DateTime ExpireDate { get; set; }
        public int CVV { get; set; }

        public int InitialAmount { get; set; }

        public int CurrentValue { get; set; }

        public AccountStatus AccountStatus { get; set; }
        public List<MasterTransactions> MasterTransactions { get; set; } = new List<MasterTransactions>();

    }
}
