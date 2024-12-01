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

        public void Handle(Exception ex, ICommand command)
        {
            _commandQueue.Enqueue(new RetryCommand(command, 2, this));
        }
    }
}