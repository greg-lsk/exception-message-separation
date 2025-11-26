namespace ExceptionMessageSeparation.MessageCreation;

internal static class MessageCreationCore
{
    internal static CreateMessage<TCaptured> Get<TCaptured, TMessage>()
        where TMessage : IExceptionMessage<TCaptured>, new()
    {
        return new TMessage().For;
    }
}