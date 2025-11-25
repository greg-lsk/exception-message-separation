using ExceptionMessageSeparation.Utils;
using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation;

public class Exception<TCaptured> : Exception, IException<TCaptured>, IMessageCreationContext<TCaptured>
{
    private readonly string? _message;
    private readonly CreateMessage<TCaptured>? _createMessage;

    public TCaptured Captured { get; }

    public override string Message
    {
        get 
        {
            if (_message is not null) return _message;
            if (_createMessage is not null) return _createMessage(this);
            return string.Empty;
        }
    }

    internal Exception(IReflectionService reflection, TCaptured captured, string? message = default, Exception? inner = default) 
        : base(string.Empty, inner)
    {
        Captured = captured;

        if (message != null) { _message = message; return; }
        _createMessage = reflection.GetMessageCreationFor<TCaptured>();
    }

    public Exception(TCaptured captured, string? message = default, Exception? inner = default)
        : this(new ReflectionService(), captured, message, inner) 
    { }
    
}