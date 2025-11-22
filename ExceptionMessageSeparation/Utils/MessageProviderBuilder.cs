using System.Linq.Expressions;


namespace ExceptionMessageSeparation.Utils;

internal static class MessageProviderBuilder
{
    internal static Func<ExceptionBase, string> Build(ExceptionBase exception)
    {
        var messageType = ReflectionUtils.GetMessageType(exception);
        if (messageType is null) return (ExceptionBase e) => string.Empty;
        var messageInstance = Activator.CreateInstance(messageType);

        var method = messageType.GetMethod("For") ?? throw new Exception("Couldn't retrieve method For");

        var childExceptionType = ReflectionUtils.GetChildExceptionType(messageType);

        var parameter = Expression.Parameter(typeof(ExceptionBase), "exception");
        var castedParameter = Expression.Convert(parameter, childExceptionType);

        var methodCall = Expression.Call(Expression.Constant(messageInstance), method, castedParameter);

        return Expression.Lambda<Func<ExceptionBase, string>>(methodCall, parameter).Compile();
    }
}