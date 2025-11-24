using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

internal class StubExceptionCapturedInfo(int anIntValue) : IHaveMessage<StubExceptionMessage>
{
    internal int AnIntValue { get; } = anIntValue;
}