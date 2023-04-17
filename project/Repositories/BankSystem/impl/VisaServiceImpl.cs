using project.Models.PaymentModels;
using project.Models.RegistrationModels.Dto;
using project.Repositories.BankSystem.Abstruct;
using project.Repositories.BankSystem.BankSystemModels;
using project.Repositories.BankSystem.Util;

namespace project.Repositories.BankSystem.impl
{
    public class VisaServiceImpl : VisaService
    {

        private readonly MyBankDbContext context;
        public VisaServiceImpl(MyBankDbContext context)
        {
            this.context = context;

        }
        public Status VisaPayment(PaymentData data, Operation operation)
        {
            




                VisaTransactions transaction = new VisaTransactions();
            
                Status status = new Status();



                if (operation == Operation.DEPOSIT)
                {
                    VisaAcounts RecieverAccount = context.VisaAccounts.Find(data.RecieverAccountNumber);

                    if (RecieverAccount == null)
                    {
                        status.StatusCode = 0;
                        status.Message = "Payment failed from visa 1 !!!";
                        return status;
                    }
                    else
                    {
                        var updatedAmount = RecieverAccount.CurrentValue + data.Amount;
                        RecieverAccount.CurrentValue = updatedAmount;
                        transaction.CardBalance = updatedAmount;
                        transaction.TransactionValue = data.Amount;
                        transaction.TransactionStatus = TransactionStatus.SUCCESS;
                        transaction.CardNumber = data.RecieverAccountNumber;
                        transaction.IssuedOn = DateTime.Now;
                        context.Attach(transaction);
                        RecieverAccount.VisaTransactions.Add(transaction);
                        context.SaveChanges();
                        status.StatusCode = 1;
                        status.Message = "Payment Succeed !!!";
                        return status;

                    }

                }
                else if (operation == Operation.WITHDRAW)
                {
                    VisaAcounts SenderAccount = context.VisaAccounts.Find(data.CardNumber);

                    if (SenderAccount == null || data.Amount > SenderAccount.CurrentValue)
                    {
                        status.StatusCode = 0;
                        status.Message = "Payment failed from visa 2!!!";
                        return status;
                    }
                    else
                    {
                        var updatedAmount = SenderAccount.CurrentValue - data.Amount;
                        SenderAccount.CurrentValue = updatedAmount;
                        transaction.CardBalance = updatedAmount;
                        transaction.TransactionValue = -data.Amount;
                        transaction.TransactionStatus = TransactionStatus.SUCCESS;
                        transaction.CardNumber = data.CardNumber;
                        context.Attach(transaction);
                        SenderAccount.VisaTransactions.Add(transaction);
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
