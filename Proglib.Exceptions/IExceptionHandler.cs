namespace Proglib.Exceptions
{
    public interface IExceptionHandler
    {
        void Handle(ICommand command, Exception exception);
    }
}