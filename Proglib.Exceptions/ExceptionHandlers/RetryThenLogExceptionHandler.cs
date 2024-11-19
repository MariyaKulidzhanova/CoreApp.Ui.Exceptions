using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions.ExceptionHandlers
{
    public class RetryThenLogExceptionHandler : IExceptionHandler
    {
        private readonly Queue<ICommand> _commandQueue;

        public RetryThenLogExceptionHandler(Queue<ICommand> commandQueue)
        {
            _commandQueue = commandQueue;
        }

        public void Handle(ICommand failedCommand, Exception ex)
        {
            var retryThenLogCommand = new RetryThenLogCommand(failedCommand);
            _commandQueue.Enqueue(retryThenLogCommand);

            var logCommand = new LogCommand(ex);
            _commandQueue.Enqueue(logCommand);
        }
    }
}