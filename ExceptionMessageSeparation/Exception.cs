using ExceptionMessageSeparation.Utils;
using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation;

public class Exception<TCaptured> : Exception, IException<TCaptured>, IMessageCreationContext<TCaptured>
{
    private readonly IMessageProvider _messageProvider;

    public TCaptured Captured { get; }
    public override string Message { get; }


    internal Exception(IMessageProvider messageProvider, TCaptured captured, string? message = default, Exception? inner = default) 
        : base(string.Empty, inner)
    {
        _messageProvider = messageProvider;

        Captured = captured;

        if (message != null) { Message = message; return; }
        Message = _messageProvider.GetFor(this);
    }

    public Exception(TCaptured captured, string? message = default, Exception? inner = default)
        : this(new MessageProvider(new Reflection()), captured, message, inner) { }
    
}