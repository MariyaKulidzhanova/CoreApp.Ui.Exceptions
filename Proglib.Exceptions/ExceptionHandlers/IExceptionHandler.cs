using Proglib.Exceptions.Commands;

namespace Proglib.Exceptions.ExceptionHandlers
{
    public interface IExceptionHandler
    {
        void Handle(ICommand command, Exception exception);
    }
}