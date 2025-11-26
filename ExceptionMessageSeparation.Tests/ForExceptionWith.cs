namespace ExceptionMessageSeparation.Tests;

public class ForExceptionWith
{
    [Fact]
    internal void Capture_AssingsTheCorrect_CapturedData()
    {
        var toBeCaptured = 10;
        
        var exception = ExceptionWith.Capture(() => toBeCaptured).Build();

        Assert.Equal(toBeCaptured, exception.Captured);
    }
}