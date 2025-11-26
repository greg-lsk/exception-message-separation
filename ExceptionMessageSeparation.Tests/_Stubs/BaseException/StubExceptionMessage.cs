using ExceptionMessageSeparation.MessageCreation;


namespace ExceptionMessageSeparation.Tests._Stubs.BaseException;

internal class StubExceptionMessage : ExceptionMessage<int>
{
    public override string For(in int captured) => $"{captured}";
}