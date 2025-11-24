namespace ExceptionMessageSeparation;

public interface IExceptionBuilder<TCaptured>
{
    public IExceptionBuilder<TCaptured> WithMessage(string message);
    public IExceptionBuilder<TCaptured> WithInnerException(Exception inner);

    public IExceptionBuilder<TCaptured> WithHResult(int HResult);
    public IExceptionBuilder<TCaptured> WithSource(string source);
    public IExceptionBuilder<TCaptured> WithHelpLink(string helpLink);

    public Exception<TCaptured> Build();
}