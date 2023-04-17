
using project.Repositories.BankSystem.Util;
using System.ComponentModel.DataAnnotations;

namespace project.Repositories.BankSystem.BankSystemModels
{
    public class MasterTransactions
    {
        [Key]
        public int TransactionId { get; set; }
        public int CardBalance { get; set; }

        public  long CardNumber { get; set; }
        public int  TransactionValue { get; set; }

        public Guid TarnsactonNumber { get; set; }

        public DateTime IssuedOn { get; set; }

        public TransactionStatus TransactionStatus { get; set; }

        public long MasterAccountID { get; set; }
        public MasterAccounts MasterAccount { get; set; }
    }
}
