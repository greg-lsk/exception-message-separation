using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

internal class StubExceptionMessage : IExceptionMessage<StubExceptionInfo>
{
    public string For(IMessageCreationContext<StubExceptionInfo> context) => $"{context.Captured.AnIntValue}";
}