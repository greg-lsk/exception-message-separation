namespace ExceptionMessageSeparation.MessageCreation;

public delegate string CreateMessage<TCaptured>(IMessageCreationContext<TCaptured> context);