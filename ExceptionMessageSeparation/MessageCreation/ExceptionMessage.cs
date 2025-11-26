namespace ExceptionMessageSeparation.MessageCreation;

public abstract class ExceptionMessage<TCaptured> : ExceptionMessageBase
{
    public abstract string For(in TCaptured captured);
}

public abstract class ExceptionMessage : ExceptionMessageBase
{
    public abstract string For();

}


public abstract class ExceptionMessageBase
{
    protected IMessageCreationContext Context { get; private set; }
    internal void SetContext(IMessageCreationContext context) => Context = context;
}