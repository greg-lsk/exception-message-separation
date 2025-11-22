using ExceptionMessageSeparation.Tests.Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests.Stubs.DifferentMessageFromBaseException;

internal class StubException_WithMessage_DifferentFromBase_Inherited : StubException, 
                                                                       IHaveMessage<StubMessage_InheritedFromBase>;

internal class StubException_WithMessage_DifferentFromBase_NewMessage : StubException, 
                                                                        IHaveMessage<StubMessage_DifferentFromBase>;