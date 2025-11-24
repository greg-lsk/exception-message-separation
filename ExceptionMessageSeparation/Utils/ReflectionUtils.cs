using ExceptionMessageSeparation.MessageCreation;

namespace ExceptionMessageSeparation.Utils;

internal static class ReflectionUtils
{
    internal static Type? GetMessageType<T>()
    {
        var retrievedTypes = typeof(T).GetInterfaces()
                                      .Where(i => i.HasGenericDefinitionOf(typeof(IHaveMessage<>)))
                                      .Select(i => i.GetGenericArguments()[0]);

        return retrievedTypes.Count() switch
        {
            0 => null,
            1 => retrievedTypes.First(),
            _ => retrievedTypes.Last()//throw new Exception("An exception can only implement one IHaveMessage<> interface")
        };
    }

    internal static bool ImplementsInterface<T>(Type iface) => typeof(T).GetInterfaces().Any(i => i.HasGenericDefinitionOf(iface));
}