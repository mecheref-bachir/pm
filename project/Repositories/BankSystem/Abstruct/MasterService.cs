using project.Models.PaymentModels;
using project.Models.RegistrationModels.Dto;
using project.Repositories.BankSystem.Util;

namespace project.Repositories.BankSystem.Abstruct
{
    public interface MasterService
    {

       Status MasterPayment(PaymentData data,Operation operation);
    }
}
