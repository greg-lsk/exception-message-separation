namespace ExceptionMessageSeparation.Tests.Stubs;

internal readonly struct StubException_FromBase_Message : IExceptionMessage<StubException_FromBase>
{
    public string For(StubException_FromBase exception) => StubExceptionMessage.Get(exception.AnIntValue, exception.AStringValue);
}