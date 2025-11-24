using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Exceptions.UnableToCast;

internal class UnableToCastMessage<TFrom, TTo> : IExceptionMessage<UnableToCastInfo<TFrom, TTo>>
{
    public string For(IMessageCreationContext<UnableToCastInfo<TFrom, TTo>> context) =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}Could not complete cast..." +
    $"{Environment.NewLine}From:: {typeof(TFrom).Name}" +
    $"{Environment.NewLine}To::   {typeof(TTo).Name}" +
    $"{Environment.NewLine}From Verbose:: {typeof(TFrom).FullName}" +
    $"{Environment.NewLine}To Verbose::   {typeof(TTo).FullName}";
}