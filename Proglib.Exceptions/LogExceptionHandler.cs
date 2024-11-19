namespace Proglib.Exceptions
{
    public class LogExceptionHandler : IExceptionHandler
    {
        private readonly Queue<ICommand> _commandQueue;

        public LogExceptionHandler(Queue<ICommand> commandQueue)
        {
            _commandQueue = commandQueue;
        }

        public void Handle(ICommand failedCommand, Exception ex)
        {
            var logCommand = new LogCommand(ex);
            _commandQueue.Enqueue(logCommand);
        }
    }
}