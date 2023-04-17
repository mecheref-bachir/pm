
using project.Repositories.Abstruct;
using System.Net.Mail;
using System.Net;

namespace project.Repositories.Impl
{
    public class SmtpServiceImpl:SmtpService

    {
        public void SendEmailTo(string receiver, string subject, string message)
        {

     

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("shoppingcartsystempm@gmail.com");
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mail.From.Address, "tkfqpehcwuhdrnkq");
            smtp.Host = "smtp.gmail.com";


            mail.To.Add(new MailAddress(receiver));
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            string st = message;

            mail.Body = st;
            smtp.Send(mail);



        }
    }
}
