namespace ExceptionMessageSeparation.Tests.Stubs.DifferentMessageFromBaseException;

internal class StubMessage_DifferentFromBase : IExceptionMessage<StubException_WithMessage_DifferentFromBase_NewMessage>
{
    public string For(StubException_WithMessage_DifferentFromBase_NewMessage exception)
        => "StubException_WithMessage_DifferentFromBase_NewMessage";
}