using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests;

public class ForMessageAssignment
{
    [Fact]
    internal void MessageAttribute_ReturnsExpectedMessage()
    {
        var exceptioncapturedInfo = new StubExceptionCapturedInfo(10);
        var exception = new Exception<StubExceptionCapturedInfo>(exceptioncapturedInfo);
        var expectedMessage = new StubExceptionMessage().For(exception);

        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }
}