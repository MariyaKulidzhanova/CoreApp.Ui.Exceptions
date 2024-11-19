namespace Proglib.Exceptions.Commands
{
    public class RetryThenLogCommand : ICommand
    {
        private readonly ICommand _command;
        private readonly int _maxRetries;

        public RetryThenLogCommand(ICommand command, int maxRetries = 2)
        {
            _command = command;
            _maxRetries = maxRetries;
        }

        public void Execute()
        {
            int attempts = 0;
            while (attempts < _maxRetries)
            {
                try
                {
                    _command.Execute();
                    return;
                }
                catch
                {
                    attempts++;
                    if (attempts == _maxRetries)
                    {
                        throw new InvalidOperationException($"Command failed after {attempts} retries.");
                    }
                }
            }
        }
    }
}