namespace ExceptionMessageSeparation.Tests.Stubs.BaseException;

internal class StubExceptionMessage : IExceptionMessage<StubException>
{
    public string For(StubException exception) => "StubExceptionMessage";
}