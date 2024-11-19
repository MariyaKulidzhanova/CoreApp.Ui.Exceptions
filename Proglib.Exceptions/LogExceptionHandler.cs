namespace Proglib.Exceptions
{
    public class LogExceptionHandler : IExceptionHandler
    {
        public void Handle(ICommand failedCommand, Exception ex)
        {
            Console.WriteLine($"Logging exception: {ex.Message}");
        }
    }
}