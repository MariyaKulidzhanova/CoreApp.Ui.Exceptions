using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions.ExceptionHandlers
{
    public class LogExceptionHandler : IExceptionHandler
    {
        private readonly Queue<ICommand> _commandQueue;

        public LogExceptionHandler(Queue<ICommand> commandQueue)
        {
            _commandQueue = commandQueue;
        }

        public void Handle(Exception ex, ICommand failedCommand)
        {
            _commandQueue.Enqueue(new LogCommand(ex, this));
        }
    }
}