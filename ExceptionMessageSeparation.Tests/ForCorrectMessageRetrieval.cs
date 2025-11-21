using ExceptionMessageSeparation.Tests.Stubs;

namespace ExceptionMessageSeparation.Tests;

public class ForCorrectMessageRetrieval
{
    public static TheoryData<IStubException> Exceptions =>
    [
        new StubException_FromBase(10, "ten"),
        new StubException_FromException(10, "ten")
    ];

    [Theory]
    [MemberData(nameof(Exceptions))]
    internal void MessageAttribute_ReturnsExpectedMessage(IStubException exception)
    {
        var expectedMessage = StubExceptionMessage.Get(exception.AnIntValue, exception.AStringValue);

        Assert.Equal(expectedMessage, (exception as Exception)!.Message);
    }
}