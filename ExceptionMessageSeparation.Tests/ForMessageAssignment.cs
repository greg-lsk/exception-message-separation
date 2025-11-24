using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests;

public class ForMessageAssignment
{
    [Fact]
    internal void MessageAttribute_ReturnsExpectedMessage_WhenNotOverriding()
    {
        var exceptioncapturedInfo = new StubExceptionInfo(10);
        var exception = new Exception<StubExceptionInfo>(exceptioncapturedInfo);
        var expectedMessage = new StubExceptionMessage().For(exception);

        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }


    [Fact]
    internal void MessageAttribute_ReturnsExpectedMessage_WhenOverriding()
    {
        var messageOverride = "This overrides the call";
        var exceptioncapturedInfo = new StubExceptionInfo(10);
        var exception = new Exception<StubExceptionInfo>(exceptioncapturedInfo, messageOverride);
        var expectedMessage = messageOverride;

        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }
}