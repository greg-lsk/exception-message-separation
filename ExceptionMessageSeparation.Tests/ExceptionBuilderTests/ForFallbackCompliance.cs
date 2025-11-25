using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests.ExceptionBuilderTests;

/// <summary>
/// <para>
/// ommit HResult cause it's per-exception-type bound: 
/// https://learn.microsoft.com/en-us/dotnet/api/system.exception.hresult?view=net-10.0#remarks
/// </para>
/// </summary>
public class ForFallbackCompliance
{
    [Fact]
    internal void LackofInnerException_CompliesTo_ExistingFallback()
    {
        var prebuiltException = new InvalidCastException();
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .Build();

        var expectedInnerException = prebuiltException.InnerException;
        var assignedInnerException = exception.InnerException;

        Assert.Equal(expectedInnerException, assignedInnerException);
    }

    [Fact]
    internal void LackofSource_CompliesTo_ExistingFallback()
    {
        var prebuiltException = new InvalidCastException();
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .Build();

        var expectedSource = prebuiltException.Source;
        var assignedSource = exception.Source;

        Assert.Equal(expectedSource, assignedSource);
    }

    [Fact]
    internal void LackofHelpLink_CompliesTo_ExistingFallback()
    {
        var prebuiltException = new InvalidCastException();
        var capturedInfo = new StubExceptionInfo(10);
        var exception = ExceptionWith<StubExceptionInfo>.Capture(capturedInfo)
                                                        .Build();

        var expectedHelpLink = prebuiltException.HelpLink;
        var assignedHelpLink = exception.HelpLink;

        Assert.Equal(expectedHelpLink, assignedHelpLink);
    }
}