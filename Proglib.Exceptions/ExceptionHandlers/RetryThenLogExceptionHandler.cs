using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions.ExceptionHandlers
{
    public class RetryThenLogExceptionHandler : IExceptionHandler
    {
        private readonly Queue<ICommand> _commandQueue;
        private readonly IExceptionHandler _logExceptionHandler;

        public RetryThenLogExceptionHandler(Queue<ICommand> commandQueue, IExceptionHandler logExceptionHandler)
        {
            _commandQueue = commandQueue;
            _logExceptionHandler = logExceptionHandler;
        }

        public void Handle(Exception ex, ICommand failedCommand)
        {
            _commandQueue.Enqueue(new RetryTwiceThenLogCommand(failedCommand, _commandQueue, _logExceptionHandler));
        }
    }
}