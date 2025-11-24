using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Exceptions.UnableToCreateInstance;

public class UnableToCreateInstanceInfo(Type instanceType) : IHaveMessage<UnableToCreateInstanceMessage>
{
    public Type InstanceType { get; } = instanceType;
}