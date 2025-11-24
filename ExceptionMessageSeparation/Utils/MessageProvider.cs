using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Utils;

internal class MessageProvider(IReflection reflection) : IMessageProvider
{
    private readonly IReflection _reflection = reflection;


    public string GetFor<TCaptured>(Exception<TCaptured> exception)
    {
        var messageType = _reflection.GetMessageType<TCaptured>();

        if (messageType is null) return string.Empty;

        var messageInstance = _reflection.CreateMessageInstance(messageType);
            
        var methodName = nameof(IExceptionMessage<TCaptured>.For);
        var method = _reflection.MessageCreationMethod(messageType, methodName, [exception.GetType()]);

        return _reflection.GetMessage(method, messageInstance, [exception]);
    }
}