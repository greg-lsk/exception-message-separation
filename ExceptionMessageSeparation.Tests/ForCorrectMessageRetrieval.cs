using ExceptionMessageSeparation.Tests.Stubs;
using ExceptionMessageSeparation.Tests.Stubs.Common;


namespace ExceptionMessageSeparation.Tests;

public class ForCorrectMessageRetrieval
{
    public static TheoryData<IStubException> Exceptions =>
    [
        new StubException(10, "ten"),
        new StubException_Child_WithNoNewMessage(1.2, 10, "ten")
    ];

    [Theory]
    [MemberData(nameof(Exceptions))]
    internal void MessageAttribute_ReturnsExpectedMessage(IStubException exception)
    {
        var expectedMessage = StubExceptionBaseMessage.Get(exception.AnIntValue, exception.AStringValue);

        Assert.Equal(expectedMessage, (exception as Exception)!.Message);
    }

    [Fact]
    internal void ChildException_WithOwnMessage_ReturnsThat()
    {
        var exception = new StubException_Child_WithNewMessage(1.2, 10, "ten");
        var expectedMessage = 
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}Double Value:: {exception.ADoubleValue}" +
            $"{Environment.NewLine}Int Value::    {exception.AnIntValue}" +
            $"{Environment.NewLine}String Value:: {exception.AStringValue}";

        Assert.Equal(expectedMessage, exception.Message);
    }
}