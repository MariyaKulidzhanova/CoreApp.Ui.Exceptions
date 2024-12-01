using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions.ExceptionHandlers
{
    public class LogExceptionHandler : IExceptionHandler
    {
        private readonly Queue<ICommand> _commandQueue;
        private readonly LogCommand _logCommand;

        public LogExceptionHandler(Queue<ICommand> commandQueue, LogCommand logCommand)
        {
            _commandQueue = commandQueue;
            _logCommand = logCommand;
        }

        public void Handle(Exception ex, ICommand failedCommand)
        {
            _commandQueue.Enqueue(_logCommand);
        }
    }
}