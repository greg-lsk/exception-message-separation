
namespace ExceptionMessageSeparation.Tests.Stubs;

internal class StubException_Child_WithNoNewMessage : StubException
{
    internal double ADoubleValue { get; }

    public StubException_Child_WithNoNewMessage(double d, int i, string s, Exception? inner = null) : base(i, s, inner)
    {
        ADoubleValue = d;
    }
}