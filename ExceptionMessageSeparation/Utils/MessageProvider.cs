using ExceptionMessageSeparation.MessageCreation;

namespace ExceptionMessageSeparation.Utils;

internal static class MessageProvider
{
    internal static string GetFor<T>(Exception<T> exception) => ReflectionUtils.ImplementsInterface<T>(typeof(IHaveMessage<>)) switch
    { 
        false => string.Empty,
        true  => GetViaReflection(exception)
    };


    private static string GetViaReflection<T>(Exception<T> exception)
    {
        var messageType = ReflectionUtils.GetMessageType<T>()
            ??throw new Exception("This shouldn't happen");

        var messageInstance = Activator.CreateInstance(messageType)
            ?? throw new Exception("Couldn't create message Instance");

        var method = messageType.GetMethod("For", [exception.GetType()])
            ?? throw new Exception("Couldn't retrieve method For");

        return method.Invoke(messageInstance, [exception]) as string
            ?? throw new Exception("Cast to string failed");
    }
}