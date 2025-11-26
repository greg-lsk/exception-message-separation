using ExceptionMessageSeparation.ExceptionBuilding;


namespace ExceptionMessageSeparation;

public static class ExceptionWith
{
    public static IExceptionBuilder<TCapture> Capture<TCapture>(Func<TCapture> capture) => new ExceptionBuilder<TCapture>(capture());
}