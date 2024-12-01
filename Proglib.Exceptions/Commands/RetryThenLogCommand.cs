using Proglib.Exceptions.ExceptionHandlers;

namespace Proglib.Exceptions.Commands
{
    public class RetryTwiceThenLogCommand : ICommand
    {
        private readonly ICommand _command;
        private readonly Queue<ICommand> _commandQueue;
        private readonly int _maxRetries;
        private readonly IExceptionHandler _logExceptionHandler;
        private int _attempts;
        private readonly LogCommand _logCommand;

        public RetryTwiceThenLogCommand(ICommand command,
                                        Queue<ICommand> commandQueue,
                                        IExceptionHandler logExceptionHandler,
                                        LogCommand logCommand,
                                        int maxRetries = 2)
        {
            _command = command;
            _commandQueue = commandQueue;
            _logExceptionHandler = logExceptionHandler;
            _maxRetries = maxRetries;
            _attempts = 0;
            _logCommand = logCommand;
        }

        public void Execute()
        {
            try
            {
                _attempts++;
                _command.Execute();
            }
            catch (Exception ex)
            {
                if (_attempts < _maxRetries)
                {
                    _commandQueue.Enqueue(new RetryTwiceThenLogCommand(_command, _commandQueue, _logExceptionHandler,
                                                                       _logCommand,
                                                                       _maxRetries));
                }
                else
                {
                    _commandQueue.Enqueue(_logCommand);
                    throw;
                }
            }
        }

        public IExceptionHandler GetExceptionHandler()
        {
            return new RetryThenLogExceptionHandler(_commandQueue, _logExceptionHandler);
        }
    }
}