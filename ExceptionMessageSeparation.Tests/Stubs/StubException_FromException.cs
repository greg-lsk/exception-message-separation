namespace ExceptionMessageSeparation.Tests.Stubs;

internal class StubException_FromException(int i, string s, Exception? inner = default) :
    Exception(string.Empty, inner),
    IStubException
{
    public int AnIntValue { get; } = i;
    public string AStringValue { get; } = s;

    public override string Message => new StubException_FromException_Message().For(this);
}