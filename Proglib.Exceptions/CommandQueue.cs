using Proglib.Exceptions.Commands;
using Proglib.Exceptions.ExceptionHandlers;

namespace Proglib.Exceptions
{
    public class CommandQueue
    {
        private Queue<ICommand> _commands = new Queue<ICommand>();
        private readonly IExceptionHandler _exceptionHandler;

        public CommandQueue(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public void Enqueue(ICommand command)
        {
            _commands.Enqueue(command);
        }

        public void ProcessCommands()
        {
            while (_commands.Count > 0)
            {
                ICommand command = _commands.Dequeue();
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    _exceptionHandler.Handle(command, ex);
                }
            }
        }
    }
}