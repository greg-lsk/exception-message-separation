using ExceptionMessageSeparation.Tests.Stubs.BaseException;
using ExceptionMessageSeparation.Tests.Stubs.SomeMessageAsBaseException;


namespace ExceptionMessageSeparation.Tests.InheritanceTest;

public class ForInheritedExceptions_WithNo_BoundNewMessage
{
    [Fact]
    internal void InheritedException_WithNo_IHaveMessageIFace_HasSameMessage_AsParent()
    {
        var parent = new StubException();
        var inherited = new StubException_SameMessageAsBase_WithoutIHaveMessage();
        var expectedMessage = new StubExceptionMessage().For(parent);

        var retrievedMessage = inherited.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }

    [Fact]
    internal void InheritedException_With_IHaveMessageIFace_HasSameMessage_AsParent()
    {
        var parent = new StubException();
        var inherited = new StubException_SameMessageAsBase_WithIHaveMessage();
        var expectedMessage = new StubExceptionMessage().For(parent);

        var retrievedMessage = inherited.Message;

        Assert.Equal(expectedMessage, retrievedMessage);
    }
}
