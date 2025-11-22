using ExceptionMessageSeparation.Tests.Stubs.Common;

namespace ExceptionMessageSeparation.Tests.Stubs;

internal class StubExceptionMessage : IExceptionMessage<StubException>
{
    public string For(StubException exception) => StubExceptionBaseMessage.Get(exception.AnIntValue, exception.AStringValue);
}