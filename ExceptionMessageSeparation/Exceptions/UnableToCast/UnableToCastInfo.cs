using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Exceptions.UnableToCast;

public class UnableToCastInfo<TFrom, TTo> : IHaveMessage<UnableToCastMessage<TFrom, TTo>>;