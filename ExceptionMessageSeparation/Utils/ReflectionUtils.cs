namespace ExceptionMessageSeparation.Utils;

internal static class ReflectionUtils
{
    internal static Type? GetMessageType(Exception exception)
    {
        var retrievedTypes = exception.GetType()
                                      .GetInterfaces()
                                      .Where(i => i.HasGenericDefinitionOf(typeof(IHaveMessage<>)))
                                      .Select(i => i.GetGenericArguments()[0]);

        return retrievedTypes.Count() switch
        {
            0 => null,
            1 => retrievedTypes.First(),
            _ => retrievedTypes.Last()//throw new Exception("An exception can only implement one IHaveMessage<> interface")
        };
    }
}