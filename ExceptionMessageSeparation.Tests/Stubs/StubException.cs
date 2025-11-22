using ExceptionMessageSeparation.Tests.Stubs.Common;


namespace ExceptionMessageSeparation.Tests.Stubs;

internal class StubException(int i, string s, Exception? inner = default) : 
    ExceptionBase(inner),
    IHaveMessage<StubExceptionMessage>,
    IStubException
{
    public int AnIntValue { get; } = i;
    public string AStringValue { get; } = s;
}