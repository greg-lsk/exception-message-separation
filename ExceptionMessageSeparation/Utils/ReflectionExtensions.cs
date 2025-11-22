namespace ExceptionMessageSeparation.Utils;

internal static class ReflectionExtensions
{
    public static bool HasGenericDefinitionOf(this Type type, Type targetType)
    {
        if (type.IsGenericType) return type.GetGenericTypeDefinition() == targetType;
        return false;
    }
}