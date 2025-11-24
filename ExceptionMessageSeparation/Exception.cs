using ExceptionMessageSeparation.Utils;
using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation;

public class Exception<T> : Exception, IException<T>, IMessageCreationContext<T>
{
    public T Context { get; }
    public override string Message { get; }


    public Exception(T context, string? message = default, Exception? inner = default) : base(string.Empty, inner)
    {
        Context = context;

        if (message != null) Message = message;
        Message = MessageProvider.GetFor(this);
    }
}