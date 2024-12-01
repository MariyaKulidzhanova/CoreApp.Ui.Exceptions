using Proglib.Exceptions.ExceptionHandlers;

namespace Proglib.Exceptions.Commands
{
    public class RetryCommand : ICommand
    {
        private readonly ICommand _command;
        private readonly int _retryCount;
        private readonly IExceptionHandler _exceptionHandler;

        public RetryCommand(ICommand command, int retryCount, IExceptionHandler exceptionHandler)
        {
            _command = command;
            _retryCount = retryCount;
            _exceptionHandler = exceptionHandler;
        }

        public void Execute()
        {
            int attempts = 0;
            while (attempts < _retryCount)
            {
                try
                {
                    _command.Execute();
                    return;
                }
                catch
                {
                    attempts++;
                    if (attempts == _retryCount)
                    {
                        throw;
                    }
                }
            }
        }

        public IExceptionHandler GetExceptionHandler()
        {
            return _exceptionHandler;
        }
    }
}