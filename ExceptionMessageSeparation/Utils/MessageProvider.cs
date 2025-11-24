using ExceptionMessageSeparation.Exceptions.UnableToCast;
using ExceptionMessageSeparation.Exceptions.UnableToCreateInstance;
using ExceptionMessageSeparation.Exceptions.UnableToRetrieveMethod;


namespace ExceptionMessageSeparation.Utils;

internal static class MessageProvider
{
    internal static string GetFor<TCaptured>(Exception<TCaptured> exception)
    {
        var messageType = ReflectionUtils.GetMessageType<TCaptured>();

        if (messageType is null) return string.Empty;

        var messageInstance = Activator.CreateInstance(messageType)
            ?? throw ExceptionWith<UnableToCreateInstanceInfo>
            .Capture(new(messageType))
            .Build();

        var methodName = "For";
        var method = messageType.GetMethod(methodName, [exception.GetType()])
            ?? throw ExceptionWith<UnableToRetrieveMethodInfo>
            .Capture(new(
                messageType,
                methodName,
                [exception.GetType()]))
            .Build();

        return method.Invoke(messageInstance, [exception]) as string
            ?? throw ExceptionWith<UnableToCastInfo<object, string>>
            .Capture(new())
            .Build();

    }
}