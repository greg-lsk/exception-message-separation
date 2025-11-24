using System.Reflection;


namespace ExceptionMessageSeparation.Utils;

internal interface IReflection
{
    internal Type? GetMessageType<TCaptured>();
    internal object CreateMessageInstance(Type messageType);
    internal MethodInfo MessageCreationMethod(Type messageType, string methodName, IEnumerable<Type> methodArguments);
    internal string GetMessage(MethodInfo createMessage, object? messageInstance, object?[]? parameters);
}