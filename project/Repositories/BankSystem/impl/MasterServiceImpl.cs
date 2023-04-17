using project.Models.PaymentModels;
using project.Models.RegistrationModels.Dto;
using project.Repositories.BankSystem.Abstruct;
using project.Repositories.BankSystem.BankSystemModels;
using project.Repositories.BankSystem.Util;


namespace project.Repositories.BankSystem.impl
{
    public class MasterServiceImpl : MasterService
    {

        private readonly MyBankDbContext context;
        public MasterServiceImpl(MyBankDbContext context)
        {
            this.context = context;
        }
        public Status  MasterPayment(PaymentData data,Operation operation)
        {
       


               
            MasterTransactions transaction = new MasterTransactions();
            Status status= new Status();



            if (operation == Operation.DEPOSIT)
            {
                MasterAccounts RecieverAccount = context.MasterAccounts.Find(data.RecieverAccountNumber);

                if (RecieverAccount == null) {
                    status.StatusCode = 0;
                    status.Message = "Payment failed from master 1!!!";
                    return status;
                }
                else
                {
                    var updatedAmount = RecieverAccount.CurrentValue + data.Amount;
                    RecieverAccount.CurrentValue = updatedAmount;
                    transaction.CardBalance = updatedAmount;
                    transaction.TransactionValue = data.Amount;
                    transaction.TransactionStatus = TransactionStatus.SUCCESS;
                    transaction.CardNumber =data.RecieverAccountNumber;
                    transaction.IssuedOn = DateTime.Now;
                    context.Attach(transaction);
                    RecieverAccount.MasterTransactions.Add(transaction);
                    context.SaveChanges();
                    status.StatusCode = 1;
                    status.Message = "Payment Succeed !!!";
                    return status;

                }

            }
            else if (operation == Operation.WITHDRAW) {
                MasterAccounts SenderAccount = context.MasterAccounts.Find(data.CardNumber);

                if (SenderAccount == null ||data.Amount > SenderAccount.CurrentValue)
                {
                    status.StatusCode = 0;
                    status.Message = "Payment failed from master 2 !!!";
                    return status;
                }
                else
                {
                    var updatedAmount = SenderAccount.CurrentValue - data.Amount;
                    SenderAccount.CurrentValue = updatedAmount;
                    transaction.CardBalance = updatedAmount;
                    transaction.TransactionValue = - data.Amount;
                    transaction.TransactionStatus = TransactionStatus.SUCCESS;
                    transaction.CardNumber = data.CardNumber;
                    transaction.IssuedOn = DateTime.Now;
                    context.Attach(transaction);
                    SenderAccount.MasterTransactions.Add(transaction);
                    context.SaveChanges();
                    status.StatusCode = 1;
                    status.Message = "Payment Succeed !!!";
                    return status;

                }
            }
            else
            {

                status.StatusCode = 0;
                status.Message = "Payment Failed !!!";
                return status;

            }



        }
    }
}

