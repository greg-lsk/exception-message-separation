using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests;

public class ForMessageAssignment
{
    [Fact]
    internal void MessageAttribute_ReturnsExpectedMessage_WhenNotOverriding()
    {
        var toBeCaptured = 10;
        var exception = ExceptionWith.Capture(() => toBeCaptured)
                                     .WithMessage<StubExceptionMessage>()
                                     .Build();

        var expectedMessage = new StubExceptionMessage().For(toBeCaptured);

        var retrievedMessage = exception.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }


    [Fact]
    internal void MessageAttribute_ReturnsExpectedMessage_WhenOverriding()
    {
        var expectedMessage = "This overrides the call";

        var exception = ExceptionWith.Capture(() => 10)
                                     .WithMessage(expectedMessage)
                                     .Build();

        Assert.Equal(expectedMessage, exception.Message);
    }
}