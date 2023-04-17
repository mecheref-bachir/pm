using project.Models.PaymentModels;
using project.Models.RegistrationModels.Dto;
using project.Repositories.BankSystem.Abstruct;
using project.Repositories.BankSystem.Util;

namespace project.Repositories.BankSystem.impl
{
    public class BankingInterfaceImpl : BankingInterface
    {


        private readonly MasterService masterService;
        private readonly VisaService visaService;

        public BankingInterfaceImpl(VisaService visaService, MasterService masterService)
        {
            this.masterService = masterService;
            this.visaService = visaService;
        }
        public Status RedirectPayment(PaymentData data)
        {
            var withdrawresult = new Status();
            withdrawresult.StatusCode = 0;

            if (data.PaymentMethod == PaymentType.VISA)
            {
                 withdrawresult = visaService.VisaPayment(data, Operation.WITHDRAW);

            }
            else if (data.PaymentMethod == PaymentType.MASTER)
            {
                 withdrawresult = masterService.MasterPayment(data, Operation.WITHDRAW);

            }



            var depositresult = new Status();
            depositresult.StatusCode = 0;

            if (data.RecieverPayementType == PaymentType.VISA)
            {
                 depositresult = visaService.VisaPayment(data, Operation.DEPOSIT);
            } 
            else if (data.RecieverPayementType == PaymentType.MASTER)
            {
                 depositresult = masterService.MasterPayment(data, Operation.DEPOSIT);
               
            }

            Status status = new Status();
            if (depositresult.StatusCode == 0 || withdrawresult.StatusCode == 0)
            {
                
                status.StatusCode = 0;
                status.Message = "payment failed from banking interface !!! " + withdrawresult.Message + depositresult.Message;
                return status;
            }

 
            status.StatusCode = 1;
            status.Message = "payment Succeed !!!";
            return status;
        }
    }
}
