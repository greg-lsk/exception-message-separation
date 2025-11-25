using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

public class StubExceptionInfo(int anIntValue) : IHaveMessage<StubExceptionMessage>
{
    public int AnIntValue { get; } = anIntValue;
}