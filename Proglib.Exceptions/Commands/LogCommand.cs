namespace Proglib.Exceptions.Commands
{
    public class LogCommand : ICommand
    {
        private readonly Exception _exception;

        public LogCommand(Exception exception)
        {
            _exception = exception;
        }

        public void Execute()
        {
            Console.WriteLine($"Logging exception: {_exception.Message}");
            // Реализовать логирование в файл или базу данных
        }
    }
}