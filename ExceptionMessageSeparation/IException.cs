using System.Collections;
using System.Reflection;


namespace ExceptionMessageSeparation;

public interface IException<TCaptured>
{
    public int HResult { get; set; }

    public string Message { get; }

    public TCaptured Captured { get; }

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