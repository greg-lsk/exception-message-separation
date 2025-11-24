using System.Reflection;
using System.Collections;


namespace ExceptionMessageSeparation;

public interface IException<T>
{
    public int HResult { get; set; }

    public string Message { get; }

    public T? Context { get; }

    public Exception? InnerException { get; }

    public string? Source { get; set; }
    public string? StackTrace { get; }
    public MethodBase? TargetSite { get; }

    public IDictionary Data { get; }
    public string? HelpLink { get; set; }


    public Type GetType();

    public int GetHashCode();
    public string ToString();

    public bool Equals(object? obj);

    public Exception GetBaseException();
}