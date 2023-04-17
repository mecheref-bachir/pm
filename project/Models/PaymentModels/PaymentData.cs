namespace project.Models.PaymentModels
{
    public class PaymentData
    {
        public string  Name { get; set; }
        public PaymentType PaymentMethod { get; set; }
        public long CardNumber { get; set; }

        public int  CVV { get; set; }

        public DateTime ExpirationDate { get; set; }

        public long RecieverAccountNumber { get; set; }

        public int  Amount  { get; set; }
        public PaymentType RecieverPayementType{ get; set; }
    }
}
