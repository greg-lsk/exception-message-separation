using System.Collections.Immutable;
using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Exceptions.UnableToRetrieveMethod;

public class UnableToRetrieveMethodMessage : ExceptionMessage<(Type OfType, string MethodName, ImmutableArray<Type> ParameterTypes)>
{
    public override string For(in (Type OfType, string MethodName, ImmutableArray<Type> ParameterTypes) captured) =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}Failed to reflect on method..." +
    $"{Environment.NewLine}Reflected Type:: {captured.OfType}" +
    $"{Environment.NewLine}MethodName::     {captured.MethodName}" +
    $"{Environment.NewLine}Parameters::     {string.Join(",", captured.ParameterTypes)}" +
    $"{Environment.NewLine}Type Verbose::   {captured.OfType.FullName}";
}