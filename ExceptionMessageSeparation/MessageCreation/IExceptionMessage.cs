namespace ExceptionMessageSeparation.MessageCreation;

public interface IExceptionMessage<TCaptured>
{
    public string For(IMessageCreationContext<TCaptured> context);
}