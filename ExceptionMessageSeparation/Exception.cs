using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation;

public class Exception<TCapture> : Exception, IExceptionContext<TCapture>, IMessageCreationContext
{
    private readonly string? _fallbackMessage;
    private readonly ExceptionMessageBase? _message;

    public TCapture? Captured { get; }
    public override string Message
    {
        get
        {
            if (_fallbackMessage is not null) return _fallbackMessage;
            if (_message is not null) return
                    Captured is not null ?
                        _message switch
                        {
                            ExceptionMessage w => w.For(),
                            ExceptionMessage<TCapture> r => r.For(Captured),
                            _ => throw new Exception("fatal flaw...")
                        }
                    : string.Empty;
            return string.Empty;
        }
    }
    
    public Exception(TCapture? capture, string? message = default, Exception? inner = default) 
        : base(message, inner) 
    {
        Captured = capture;

        _message = null;
        _fallbackMessage = message is not null ? message : string.Empty;
    }

    public Exception(TCapture? capture, ExceptionMessageBase? message = default, Exception? inner = default)
        : base(string.Empty, inner)
    {
        Captured = capture;

        _message = message;
        _message?.SetContext(this);

        _fallbackMessage = null;
    }
}