using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Utils;

internal static class ReflectionUtils
{
    internal static Type? GetMessageType<TCaptured>()
    {
        var retrievedTypes = typeof(TCaptured).GetInterfaces()
                                              .Where(i => i.HasGenericDefinitionOf(typeof(IHaveMessage<>)))
                                              .Select(i => i.GetGenericArguments()[0]);

        return retrievedTypes.Count() switch
        {
            0 => null,
            1 => retrievedTypes.First(),
            _ => retrievedTypes.Last()
        };
    }

    internal static bool ImplementsInterface<TCaptured>(Type iface) 
        => typeof(TCaptured).GetInterfaces().Any(i => i.HasGenericDefinitionOf(iface));
}