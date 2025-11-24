namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

internal class StubExceptionContext(int anIntValue) : IHaveMessage<StubExceptionMessage>
{
    internal int AnIntValue { get; } = anIntValue;
}