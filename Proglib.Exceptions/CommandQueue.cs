namespace Proglib.Exceptions
{
    public class CommandQueue
    {
        private Queue<ICommand> _commands = new Queue<ICommand>();

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
                    //LogExceptionHandler.Handle(command, ex);
                }
            }
        }
    }
}