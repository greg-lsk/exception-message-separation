using ExceptionMessageSeparation.Tests.Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests;

public class ForMessageAssignment
{
    [Fact]
    internal void MessageAttribute_ReturnsExpectedMessage()
    {
        var exception = new StubException();
        var expectedMessage = new StubExceptionMessage().For(exception);

        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }
}