using System.Collections.Immutable;


namespace ExceptionMessageSeparation.Exceptions.UnableToRetrieveMethod;

public class UnableToRetrieveMethodInfo(Type ofType, string methodName, IEnumerable<Type> parameterTypes)
{
    public Type OfType { get; } = ofType;
    public string MethodName { get; } = methodName;
    public ImmutableArray<Type> ParameterTypes { get; } = [.. parameterTypes];
}