namespace ExceptionMessageSeparation.Tests.Stubs;


internal class StubException_Child_WithNewMessage : StubException, IHaveMessage<StubException_Child_WithNewMessage_Message>
{
    internal double ADoubleValue { get; }

    public StubException_Child_WithNewMessage(double d, int i, string s, Exception? inner = null) : base(i, s, inner)
    {
        ADoubleValue = d;
    }
}