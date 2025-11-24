using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

internal class StubExceptionMessage : IExceptionMessage<StubExceptionCapturedInfo>
{
    public string For(IMessageCreationContext<StubExceptionCapturedInfo> context) => $"{context.Captured.AnIntValue}";
}