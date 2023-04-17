using project.Models.PaymentModels;
using project.Models.RegistrationModels.Dto;
using project.Repositories.BankSystem.Util;

namespace project.Repositories.BankSystem.Abstruct
{
    public interface VisaService
    {

        Status VisaPayment(PaymentData data,Operation operation);
    }
}
