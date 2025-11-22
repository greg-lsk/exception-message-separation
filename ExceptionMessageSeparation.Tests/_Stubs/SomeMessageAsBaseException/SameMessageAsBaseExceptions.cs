using ExceptionMessageSeparation.Tests.Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests.Stubs.SomeMessageAsBaseException;

internal class StubException_SameMessageAsBase_WithoutIHaveMessage : StubException;
internal class StubException_SameMessageAsBase_WithIHaveMessage : StubException, 
                                                                  IHaveMessage<StubExceptionMessage>;