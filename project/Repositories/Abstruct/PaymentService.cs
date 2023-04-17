
using project.Models.PaymentModels;
using project.Models.RegistrationModels.Dto;
namespace project.Repositories.Abstruct
{
    public interface PaymentService
    {

        Status VendorPayment(PaymentData data);

        Status OrderPayement();
    }
}
