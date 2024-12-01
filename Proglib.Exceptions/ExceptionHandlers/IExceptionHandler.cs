using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions.ExceptionHandlers
{
    public interface IExceptionHandler
    {
        void Handle(Exception exception, ICommand command);
    }
}