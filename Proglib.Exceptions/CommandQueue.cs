using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions
{
    public class CommandQueue
    {
        private Queue<ICommand> _commands;

        public CommandQueue(Queue<ICommand> commands)
        {
            _commands = commands;
        }

        public void ProcessCommands()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    var handler = command.GetExceptionHandler();
                    handler?.Handle(ex, command);
                }
            }
        }
    }
}