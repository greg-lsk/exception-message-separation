using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests;

public class ForExceptionWith
{
    [Fact]
    internal void Capture_AssingsTheCorrect_CapturedData()
    {
        var expectedCapturedInfo = new StubExceptionCapturedInfo(10);
        var exception = ExceptionWith<StubExceptionCapturedInfo>.Capture(expectedCapturedInfo)
                                                                .Build();
        var assignedCapturedInfo = exception.Captured;
        Assert.Equal(expectedCapturedInfo, assignedCapturedInfo);
    }
}