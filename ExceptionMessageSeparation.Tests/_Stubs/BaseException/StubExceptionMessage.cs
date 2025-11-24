namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

internal class StubExceptionMessage : IExceptionMessage<StubExceptionContext>
{
    public string For(Exception<StubExceptionContext> exception) => $"{exception.Context.AnIntValue}";
}