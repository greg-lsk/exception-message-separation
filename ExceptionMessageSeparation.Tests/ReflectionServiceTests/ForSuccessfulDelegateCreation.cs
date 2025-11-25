using Moq;
using ExceptionMessageSeparation.Utils;
using ExceptionMessageSeparation.MessageCreation;
using ExceptionMessageSeparation.Tests._Stubs.BaseException;


namespace ExceptionMessageSeparation.Tests.ReflectionServiceTests;

public class ForSuccessfulDelegateCreation
{
    [Fact]
    internal void TypeThatImplements_IExceptionMessage_ReturnsExpectedDelegate()
    {
        var reflectionService = new ReflectionService();
        var expectedDelegateType = typeof(CreateMessage<StubExceptionInfo>);

        var retrievedDelegateType = reflectionService.GetMessageCreationFor<StubExceptionInfo>().GetType();

        Assert.Equal(expectedDelegateType, retrievedDelegateType);
    }

    [Fact]
    internal void TypeThatDoesNotImplements_IExceptionMessage_ReturnsExpectedDelegate()
    {
        var reflectionService = new ReflectionService();
        var expectedDelegateType = typeof(CreateMessage<StubExceptionInfoNoMessage>);

        var retrievedDelegateType = reflectionService.GetMessageCreationFor<StubExceptionInfoNoMessage>().GetType();

        Assert.Equal(expectedDelegateType, retrievedDelegateType);
    }

    [Fact]
    internal void Delegate_OfTypeThatImplements_IExceptionMessage_ReturnsExpectedMessage()
    {
        var expectedMessage = "15";
        
        var stubInfo = new StubExceptionInfo(15);
        var reflectionService = new ReflectionService();
        var messageCreation = reflectionService.GetMessageCreationFor<StubExceptionInfo>();

        var mockCreationContext = new Mock<IMessageCreationContext<StubExceptionInfo>>();
        mockCreationContext.Setup(m => m.Captured).Returns(stubInfo);

        var retrievedMessage = messageCreation(mockCreationContext.Object);

        Assert.Equal(expectedMessage, retrievedMessage);
    }

    [Fact]
    internal void Delegate_OfTypeThatDoesNotImplements_IExceptionMessage_ReturnsEmptyString()
    {
        var expectedMessage = string.Empty;

        var reflectionService = new ReflectionService();
        var messageCreation = reflectionService.GetMessageCreationFor<StubExceptionInfoNoMessage>();
        
        var mockCreationContext = new Mock<IMessageCreationContext<StubExceptionInfoNoMessage>>();

        var retrievedMessage = messageCreation(mockCreationContext.Object);

        Assert.Equal(expectedMessage, retrievedMessage);
    }
}