namespace Lab06.Services
{
    public interface IEmailService
    {
        void SendEmail(string recipient, string subject, string body);
    }
}