using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests;

public class ForMessageAssignment
{
    [Fact]
    internal void MessageAttribute_ReturnsExpectedMessage()
    {
        var exceptionContext = new StubExceptionContext(10);
        var exception = new Exception<StubExceptionContext>(exceptionContext);

        var expectedMessage = new StubExceptionMessage().For(exception);
        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }
}