using System.Linq.Expressions;


namespace ExceptionMessageSeparation.Utils;

internal static class MessageProviderBuilder
{
    internal static Func<Exception, string> Build(Exception exception)
    {
        var messageType = ReflectionUtils.GetMessageType(exception);
        if (messageType is null) return ex => string.Empty;
        var messageInstance = Activator.CreateInstance(messageType);

        var method = messageType.GetMethod("For", [exception.GetType()]) 
            ?? throw new Exception("Couldn't retrieve method For");

        var parameter = Expression.Parameter(typeof(Exception), "exception");
        var castedParameter = Expression.Convert(parameter, exception.GetType());

        var methodCall = Expression.Call(Expression.Constant(messageInstance), method, castedParameter);

        return Expression.Lambda<Func<Exception, string>>(methodCall, parameter).Compile();
    }
}