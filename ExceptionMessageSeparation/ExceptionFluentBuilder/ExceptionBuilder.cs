
namespace ExceptionMessageSeparation.ExceptionFluentBuilder;

internal sealed class ExceptionBuilder<TCaptured>(TCaptured captured) : IExceptionBuilder<TCaptured>
{
    private TCaptured Captured { get; } = captured;

    private string? Message { get; set; }
    private Exception? InnerException { get; set; }

    private int? HResult { get; set; }
    private string? Source { get; set; }
    private string? HelpLink { get; set; }


    public IExceptionBuilder<TCaptured> WithMessage(string message)
    {
        Message = message;
        return this;
    }

    public IExceptionBuilder<TCaptured> WithInnerException(Exception inner)
    {
        InnerException = inner;
        return this;
    }

    public IExceptionBuilder<TCaptured> WithHResult(int hResult)
    {
        HResult = hResult;
        return this;
    }

    public IExceptionBuilder<TCaptured> WithSource(string source)
    {
        Source = source;
        return this;
    }

    public IExceptionBuilder<TCaptured> WithHelpLink(string helpLink)
    {
        HelpLink = helpLink;
        return this;
    }

    public Exception<TCaptured> Build()
    {
        var exception = new Exception<TCaptured>(Captured, Message, InnerException);

        if (Source != null) exception.Source = Source;
        if (HelpLink != null) exception.HelpLink = HelpLink;
        if (HResult.HasValue) exception.HResult = HResult.Value;

        return exception;
    }
}