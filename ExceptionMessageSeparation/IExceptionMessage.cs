namespace ExceptionMessageSeparation;

public interface IExceptionMessage<TException> where TException : Exception
{
    public string For(TException exception);
}