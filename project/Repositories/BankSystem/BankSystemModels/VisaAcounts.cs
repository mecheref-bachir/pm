using project.Repositories.BankSystem.Util;
using System.ComponentModel.DataAnnotations;

namespace project.Repositories.BankSystem.BankSystemModels
{
    public class VisaAcounts
    {
        [Key]
        public long CartNumber { get; set; }
        public string NameOnCard { get; set; }

        public DateTime ExpireDate { get; set; }
        public int CVV { get; set; }

        public int InitialAmount { get; set; }

        public int CurrentValue { get; set; }

        public AccountStatus AccountStatus { get; set; }
        public List<VisaTransactions> VisaTransactions { get; set; } = new List<VisaTransactions>();
    }
}
