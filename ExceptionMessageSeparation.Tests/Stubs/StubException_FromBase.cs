namespace ExceptionMessageSeparation.Tests.Stubs;

internal class StubException_FromBase(int i, string s, Exception? inner = default) : 
    ExceptionBase<StubException_FromBase, StubException_FromBase_Message>(inner), 
    IStubException
{
    public int AnIntValue { get; } = i;
    public string AStringValue { get; } = s;
}