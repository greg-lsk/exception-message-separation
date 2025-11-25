using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests.ExceptionBuilderTests;

public class ForAssigningExceptionProperties
{
    [Fact]
    internal void WithMessage_AssignsValue_Correctly()
    {
        var expectedMessage = "a message";
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .WithMessage(expectedMessage)
                                                        .Build();

        var assignedMessage = exception.Message;

        Assert.Equal(expectedMessage, assignedMessage);
    }

    [Fact]
    internal void WithInnerException_AssignsValue_Correctly()
    {
        var expectedInnerException = new InvalidCastException();
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .WithInnerException(expectedInnerException)
                                                        .Build();

        var assignedInnerException = exception.InnerException;

        Assert.Equal(expectedInnerException, assignedInnerException);
    }

    [Fact]
    internal void WithHResult_AssignsValue_Correctly()
    {
        var expectedHResult = 80;
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .WithHResult(expectedHResult)
                                                        .Build();

        var assignedHResult = exception.HResult;

        Assert.Equal(expectedHResult, assignedHResult);
    }

    [Fact]
    internal void WithSource_AssignsValue_Correctly()
    {
        var expectedSouce = nameof(WithSource_AssignsValue_Correctly);
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .WithSource(expectedSouce)
                                                        .Build();

        var assignedSource = exception.Source;

        Assert.Equal(expectedSouce, assignedSource);
    }

    [Fact]
    internal void WithHelpLink_AssignsValue_Correctly()
    {
        var expectedHelpLink = "https:// fakelink domain";
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .WithHelpLink(expectedHelpLink)
                                                        .Build();

        var assignedHelpLink = exception.HelpLink;

        Assert.Equal(expectedHelpLink, assignedHelpLink);
    }
}