using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Utils;

internal interface IReflectionService
{
    internal CreateMessage<TCaptured> GetMessageCreationFor<TCaptured>();
}