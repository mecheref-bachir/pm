namespace project.Repositories.Abstruct
{
    public interface SmtpService
    {
        public void SendEmailTo(string receiver, string subject, string message);
    }
}
