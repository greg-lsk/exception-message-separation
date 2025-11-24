using System.Reflection;
using ExceptionMessageSeparation.MessageCreation;
using ExceptionMessageSeparation.Exceptions.UnableToCast;
using ExceptionMessageSeparation.Exceptions.UnableToCreateInstance;
using ExceptionMessageSeparation.Exceptions.UnableToRetrieveMethod;


namespace ExceptionMessageSeparation.Utils;

internal class Reflection : IReflection
{
    public Type? GetMessageType<TCaptured>()
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

    public object CreateMessageInstance(Type messageType) => 
        Activator.CreateInstance(messageType)
        ?? throw ExceptionWith<UnableToCreateInstanceInfo>.Capture
        (
            new(messageType)
        )
        .Build();

    public MethodInfo MessageCreationMethod(Type messageType, string methodName, IEnumerable<Type> methodArguments)
    {
        return messageType.GetMethod(methodName, [..methodArguments])
        ?? throw ExceptionWith<UnableToRetrieveMethodInfo>.Capture
        (
            new(
            messageType,
            methodName,
            methodArguments)
        )
        .Build();
    }

    public string GetMessage(MethodInfo createMessage, object? messageInstance, object?[]? parameters)
    {
        return createMessage.Invoke(messageInstance, parameters) as string
        ?? throw ExceptionWith<UnableToCastInfo<object, string>>.Capture(new()).Build(); 
    }
}