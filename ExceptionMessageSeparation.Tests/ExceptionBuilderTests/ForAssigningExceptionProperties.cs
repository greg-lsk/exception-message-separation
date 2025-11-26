namespace ExceptionMessageSeparation.Tests.ExceptionBuilderTests;

public class ForAssigningExceptionProperties
{
    [Fact]
    internal void WithMessage_AssignsValue_Correctly()
    {
        var expectedMessage = "a message";
        var exception = ExceptionWith.Capture(() => 10)
                                     .WithMessage(expectedMessage)
                                     .Build();

        var assignedMessage = exception.Message;

        Assert.Equal(expectedMessage, assignedMessage);
    }

    [Fact]
    internal void WithInnerException_AssignsValue_Correctly()
    {
        var expectedInnerException = new InvalidCastException();
        var exception = ExceptionWith.Capture(() => 10)
                                     .WithInnerException(expectedInnerException)
                                     .Build();

        var assignedInnerException = exception.InnerException;

        Assert.Equal(expectedInnerException, assignedInnerException);
    }

    [Fact]
    internal void WithHResult_AssignsValue_Correctly()
    {
        var expectedHResult = 80;
        var exception = ExceptionWith.Capture(() => 10)
                                     .WithHResult(expectedHResult)
                                     .Build();

        var assignedHResult = exception.HResult;

        Assert.Equal(expectedHResult, assignedHResult);
    }

    [Fact]
    internal void WithSource_AssignsValue_Correctly()
    {
        var expectedSouce = nameof(WithSource_AssignsValue_Correctly);
        var exception = ExceptionWith.Capture(() => 10)
                                     .WithSource(expectedSouce)
                                     .Build();

        var assignedSource = exception.Source;

        Assert.Equal(expectedSouce, assignedSource);
    }

    [Fact]
    internal void WithHelpLink_AssignsValue_Correctly()
    {
        var expectedHelpLink = "https:// fakelink domain";
        var exception = ExceptionWith.Capture(() => 10)
                                     .WithHelpLink(expectedHelpLink)
                                     .Build();

        var assignedHelpLink = exception.HelpLink;

        Assert.Equal(expectedHelpLink, assignedHelpLink);
    }
}