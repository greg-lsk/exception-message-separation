using ExceptionMessageSeparation.MessageCreation;

namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

internal class StubExceptionMessage : IExceptionMessage<StubExceptionContext>
{
    public string For(IMessageCreationContext<StubExceptionContext> context) => $"{context.Context.AnIntValue}";
}