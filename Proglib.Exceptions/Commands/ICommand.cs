using Proglib.Exceptions.ExceptionHandlers;

namespace Proglib.Exceptions.Commands
{
    public interface ICommand
    {
        void Execute();
        IExceptionHandler GetExceptionHandler();
    }
}