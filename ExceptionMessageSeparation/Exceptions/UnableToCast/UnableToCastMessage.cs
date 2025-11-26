using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Exceptions.UnableToCast;

internal class UnableToCastMessage<TFrom, TTo> : ExceptionMessage
{
    public override string For() =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}Could not complete cast..." +
    $"{Environment.NewLine}From:: {typeof(TFrom).Name}" +
    $"{Environment.NewLine}To::   {typeof(TTo).Name}" +
    $"{Environment.NewLine}From Verbose:: {typeof(TFrom).FullName}" +
    $"{Environment.NewLine}To Verbose::   {typeof(TTo).FullName}";
}