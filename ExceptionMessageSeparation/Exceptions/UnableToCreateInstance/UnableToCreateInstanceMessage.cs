using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Exceptions.UnableToCreateInstance;

public class UnableToCreateInstanceMessage : IExceptionMessage<UnableToCreateInstanceInfo>
{
    public string For(IMessageCreationContext<UnableToCreateInstanceInfo> context) =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}Failed to create an instance via reflection" +
    $"{Environment.NewLine}Reflected Type:: {context.Captured.InstanceType}" +
    $"{Environment.NewLine}Type Verbose::   {context.Captured.InstanceType.FullName}";
}