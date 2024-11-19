namespace Proglib.Exceptions
{
    public class RetryExceptionHandler : IExceptionHandler
    {
        public void Handle(ICommand failedCommand, Exception ex)
        {
            Console.WriteLine($"Retrying command due to exception: {ex.Message}");
        }
    }
}