namespace ExceptionMessageSeparation.Utils;

internal static class ReflectionUtils
{
    internal static Type? GetMessageType(ExceptionBase exception)
    {
        var retrievedTypes = exception.GetType()
                                      .GetInterfaces()
                                      .Where(i => i.HasGenericDefinitionOf(typeof(IHaveMessage<>)))
                                      .Select(i => i.GetGenericArguments()[0]);

        return retrievedTypes.Count() switch
        {
            0 => null,
            1 => retrievedTypes.First(),
            _ => retrievedTypes.Last()
        };
    }

    internal static Type? GetChildExceptionType(Type messageType)
    {
        var retirevedTypes = messageType.GetInterfaces()
                                        .Where(i => i.HasGenericDefinitionOf(typeof(IExceptionMessage<>)))
                                        .Select(i => i.GetGenericArguments()[0]);

        return retirevedTypes.Count() switch
        {
            0 => throw new Exception("Exception found with dictated message, but message is not bound to exception"),
            1 => retirevedTypes.First(),
            _ => throw new Exception("A message can only implement one IExceptionMessage<> interface")
        };
    }
}