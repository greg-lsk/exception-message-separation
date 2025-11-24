using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Exceptions.UnableToRetrieveMethod;

public class UnableToRetrieveMethodMessage : IExceptionMessage<UnableToRetrieveMethodInfo>
{
    public string For(IMessageCreationContext<UnableToRetrieveMethodInfo> context) =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}Failed to reflect on method..." +
    $"{Environment.NewLine}Reflected Type:: {context.Captured.OfType}" +
    $"{Environment.NewLine}MethodName::     {context.Captured.MethodName}" +
    $"{Environment.NewLine}Parameters::     {string.Join(",", context.Captured.ParameterTypes)}" +
    $"{Environment.NewLine}Type Verbose::   {context.Captured.OfType.FullName}";
}