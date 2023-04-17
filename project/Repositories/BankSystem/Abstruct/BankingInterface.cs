using project.Models.PaymentModels;
using project.Models.RegistrationModels.Dto;


namespace project.Repositories.BankSystem.Abstruct
{
    public interface BankingInterface
    {


        Status RedirectPayment(PaymentData data);
    }
}
