using project.Models.RegistrationModels.Dto;
using project.Repositories.Abstruct;
using project.Models.PaymentModels;
using project.Repositories.BankSystem.Abstruct;

namespace project.Repositories.Impl
{
    public class PaymentServiceImpl : PaymentService
    {

        private readonly BankingInterface bankingInterface;
        public PaymentServiceImpl(BankingInterface bankingInterface)
        {
            this.bankingInterface = bankingInterface;
        }
        public Status OrderPayement()
        {
            throw new NotImplementedException();
        }

        public Status VendorPayment(PaymentData data)
        {
            data.Amount = 2000;
            var result = bankingInterface.RedirectPayment(data);
            return result;

        }
    }
}
