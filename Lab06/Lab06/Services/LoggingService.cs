namespace Lab06.Services
{
    public class LoggingService : ILoggingService
    {
        public void Log(string message)
        {
            // Ghi log ra màn hình console (Debug)
            Console.WriteLine($"[Logger - Singleton]: {message}");
        }
    }
}