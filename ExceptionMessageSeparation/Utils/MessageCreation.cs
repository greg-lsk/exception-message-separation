using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Utils;

internal static class MessageCreation
{
    internal static CreateMessage<TCaptured> Get<TCaptured, TMessage>()
        where TMessage : IExceptionMessage<TCaptured>, new()
    {
        return new TMessage().For;
    }
}