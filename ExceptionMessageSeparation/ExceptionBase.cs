using ExceptionMessageSeparation.Utils;


namespace ExceptionMessageSeparation;

/// <summary>
/// Serves as an abstract base class for custom exceptions.
/// </summary>
/// <remarks>
/// This class ensures that exceptions can be created with standard messaging logic,
/// while allowing for flexibility and separation of exception message definition 
/// from the exception class definition.
/// </remarks>
public abstract class ExceptionBase : Exception
{
    private readonly Func<ExceptionBase, string> _getMessage;

    public override string Message => _getMessage(this);


    public ExceptionBase(Exception? inner = default) : base(string.Empty, inner)
    {
        _getMessage = MessageProviderBuilder.Build(this);
    }
}