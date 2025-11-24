using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Utils;

internal static class ReflectionUtils
{
    internal static Type? GetMessageType<TCaptured>()
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
}