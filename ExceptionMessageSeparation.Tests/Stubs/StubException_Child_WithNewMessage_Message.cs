namespace ExceptionMessageSeparation.Tests.Stubs;

internal class StubException_Child_WithNewMessage_Message : ExceptionBase, IExceptionMessage<StubException_Child_WithNewMessage>
{
    public string For(StubException_Child_WithNewMessage exception) =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}Double Value:: {exception.ADoubleValue}" +
    $"{Environment.NewLine}Int Value::    {exception.AnIntValue}" +
    $"{Environment.NewLine}String Value:: {exception.AStringValue}";
}
