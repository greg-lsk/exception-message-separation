using ExceptionMessageSeparation.ExceptionFluentBuilder;


namespace ExceptionMessageSeparation;

public static class ExceptionWith<TCaptured>
{
    public static IExceptionBuilder<TCaptured> Capture(TCaptured captured) => new ExceptionBuilder<TCaptured>(captured);
}