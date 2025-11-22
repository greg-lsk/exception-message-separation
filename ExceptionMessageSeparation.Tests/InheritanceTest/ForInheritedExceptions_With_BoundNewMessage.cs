using ExceptionMessageSeparation.Tests.Stubs.DifferentMessageFromBaseException;


namespace ExceptionMessageSeparation.Tests.InheritanceTest;

public class ForInheritedExceptions_With_BoundNewMessage
{
    [Fact]
    internal void InheritedException_WithInheritedMessage_YieldsCorrectResult()
    {
        var exception = new StubException_WithMessage_DifferentFromBase_Inherited();
        var expectedMessage = new StubMessage_InheritedFromBase().For(exception);

        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }

    [Fact]
    internal void InheritedException_WithNewMessage_YieldsCorrectResult()
    {
        var exception = new StubException_WithMessage_DifferentFromBase_NewMessage();
        var expectedMessage = new StubMessage_DifferentFromBase().For(exception);

        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }
}