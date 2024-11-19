using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions.ExceptionHandlers
{
    public class RetryExceptionHandler : IExceptionHandler
    {
        private readonly Queue<ICommand> _commandQueue;

        public RetryExceptionHandler(Queue<ICommand> commandQueue)
        {
            _commandQueue = commandQueue;
        }

        public void Handle(ICommand failedCommand, Exception ex)
        {
            var retryCommand = new RetryCommand(failedCommand, 2);
            _commandQueue.Enqueue(retryCommand);
        }
    }
}