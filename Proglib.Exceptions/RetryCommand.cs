using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglib.Exceptions
{
    public class RetryCommand : ICommand
    {
        private readonly ICommand _command;
        private readonly int _retryCount;

        public RetryCommand(ICommand command, int retryCount)
        {
            _command = command;
            _retryCount = retryCount;
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
    }
}