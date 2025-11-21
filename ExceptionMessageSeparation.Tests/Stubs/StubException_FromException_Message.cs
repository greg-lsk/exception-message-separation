namespace ExceptionMessageSeparation.Tests.Stubs;

internal readonly struct StubException_FromException_Message : IExceptionMessage<StubException_FromException>
{
    public string For(StubException_FromException exception) => StubExceptionMessage.Get(exception.AnIntValue, exception.AStringValue);
}