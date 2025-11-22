using ExceptionMessageSeparation.Tests.Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests.Stubs.DifferentMessageFromBaseException;

internal class StubMessage_InheritedFromBase : StubExceptionMessage,
                                               IExceptionMessage<StubException_WithMessage_DifferentFromBase_Inherited>
{
    public string For(StubException_WithMessage_DifferentFromBase_Inherited exception) 
        => String.Concat([base.For(exception), "StubException_WithMessage_DifferentFromBase_Inherited"]);
}