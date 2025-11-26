using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.ExceptionBuilding;

internal sealed class ExceptionBuilder<TCaptured>(TCaptured captured) : IExceptionBuilder<TCaptured>
{
    private TCaptured Captured { get; } = captured;

    private string? Message { get; set; }
    private ExceptionMessage<TCaptured>? CreateMessage {get; set;}
    
    private Exception? InnerException { get; set; }

    private int? HResult { get; set; }
    private string? Source { get; set; }
    private string? HelpLink { get; set; }


    public IExceptionBuilder<TCaptured> WithMessage(string message)
    {
        Message = message;
        return this;
    }

    public IExceptionBuilder<TCaptured> WithMessage<TMessage>() where TMessage : ExceptionMessage<TCaptured>, new()
    {
        CreateMessage = new TMessage();
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
        var creationKind = (Message is null, CreateMessage is null);
        var exception = creationKind switch
        {
            (false, _)    => new Exception<TCaptured>(Captured, Message, InnerException),
            (true, true)  => new Exception<TCaptured>(Captured, string.Empty, InnerException),
            (true, false) => new Exception<TCaptured>(Captured, CreateMessage!, InnerException)
        };

        if (Source != null) exception.Source = Source;
        if (HelpLink != null) exception.HelpLink = HelpLink;
        if (HResult.HasValue) exception.HResult = HResult.Value;

        return exception;
    }
}