using System.Reflection;
using System.Collections;


namespace ExceptionMessageSeparation.MessageCreation;

public interface IMessageCreationContext 
{
    public int HResult { get; }

    public Exception? InnerException { get; }

    public string? Source { get; }
    public string? StackTrace { get; }
    public MethodBase? TargetSite { get; }

    public IDictionary Data { get; }
    public string? HelpLink { get; }


    public Type GetType();

    public int GetHashCode();
    public string ToString();

    public bool Equals(object? obj);

    public Exception GetBaseException();
}