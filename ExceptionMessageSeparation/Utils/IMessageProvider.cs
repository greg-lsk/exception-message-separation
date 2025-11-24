namespace ExceptionMessageSeparation.Utils;

internal interface IMessageProvider
{
    public string GetFor<TCaptured>(Exception<TCaptured> exception);
}