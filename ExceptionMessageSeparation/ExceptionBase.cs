namespace ExceptionMessageSeparation;

public abstract class ExceptionBase<TChildException, TChildExceptionString>(Exception? inner = default) : Exception(string.Empty, inner)
    where TChildException : ExceptionBase<TChildException, TChildExceptionString>
    where TChildExceptionString : struct, IExceptionMessage<TChildException>
{
    public override string Message => new TChildExceptionString().For((TChildException)this);
}