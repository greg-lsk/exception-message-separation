using System.Reflection;
using ExceptionMessageSeparation.MessageCreation;
using ExceptionMessageSeparation.Exceptions.UnableToCast;
using ExceptionMessageSeparation.Exceptions.UnableToRetrieveMethod;


namespace ExceptionMessageSeparation.Utils;

internal class ReflectionService : IReflectionService
{
    public CreateMessage<TCaptured> GetMessageCreationFor<TCaptured>()
    {
        var messageType = GetMessageType<TCaptured>();
        if (messageType is null) return (e) => string.Empty;

        var messageCreation = GetMessageCreationInfo<TCaptured>(messageType);

        return messageCreation.Invoke(null, null) as CreateMessage<TCaptured>
        ?? throw ExceptionWith<UnableToCastInfo<object, CreateMessage<TCaptured>>>.Capture(new()).Build();
    }


    private static Type? GetMessageType<TCaptured>()
    {
        var retrievedTypes = typeof(TCaptured).GetInterfaces()
                                              .Where(i => i.GetGenericTypeDefinition() == typeof(IHaveMessage<>))
                                              .Select(i => i.GetGenericArguments()[0]);

        return retrievedTypes.Count() switch
        {
            0 => null,
            1 => retrievedTypes.First(),
            _ => retrievedTypes.Last()
        };
    }

    private static MethodInfo GetMessageCreationInfo<TCaptured>(Type messageType)
    {
        var sourceType = typeof(MessageCreation);
        var methodName = nameof(MessageCreation.Get);
        var bindingAttr = BindingFlags.Static | BindingFlags.NonPublic;

        var method = sourceType.GetMethod(methodName, bindingAttr)
            ?? throw ExceptionWith<UnableToRetrieveMethodInfo>
            .Capture(new(sourceType, methodName, []))
            .Build();

        return method.MakeGenericMethod(typeof(TCaptured), messageType);
    }
}