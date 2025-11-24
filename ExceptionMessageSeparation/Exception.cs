using ExceptionMessageSeparation.Utils;
using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation;

public class Exception<TCaptured> : Exception, IException<TCaptured>, IMessageCreationContext<TCaptured>
{
    public TCaptured Captured { get; }
    public override string Message { get; }


    public Exception(TCaptured captured, string? message = default, Exception? inner = default) : base(string.Empty, inner)
    {
        Captured = captured;

        if (message != null) Message = message;
        Message = MessageProvider.GetFor(this);
    }
}