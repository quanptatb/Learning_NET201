namespace Lab06.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string recipient, string subject, string body)
        {
            Console.WriteLine($"[Email - Transient]: Sending to {recipient} | Subject: {subject} | Body: {body}");
        }
    }
}