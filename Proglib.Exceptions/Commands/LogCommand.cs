using Proglib.Exceptions.ExceptionHandlers;

namespace Proglib.Exceptions.Commands
{
    public class LogCommand : ICommand
    {
        private readonly Exception _exception;
        private readonly IExceptionHandler _exceptionHandler;

        public LogCommand(Exception exception, IExceptionHandler exceptionHandler)
        {
            _exception = exception;
            _exceptionHandler = exceptionHandler;
        }

        public void Execute()
        {
            Console.WriteLine($"Logging exception: {_exception.Message}");
        }

        public IExceptionHandler GetExceptionHandler()
        {
            return _exceptionHandler;
        }
    }
}