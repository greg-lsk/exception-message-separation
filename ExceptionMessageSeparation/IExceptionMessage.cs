namespace ExceptionMessageSeparation;

/// <summary>
/// Defines a contract for creating exception messages.
/// </summary>
/// <typeparam name="TException">The type of the exception that this interface applies to.</typeparam>
/// <remarks>
/// The <typeparamref name="TException"/> type specified in this interface 
/// should implement the <see cref="IHaveMessage{TMessage}"/> interface, 
/// where the generic type argument <typeparamref name="TMessage"/> can be:
/// <para>- the same as the type implementing this interface</para>
/// <para>- a base type of the type implementing this interface</para> 
/// </remarks> 
public interface IExceptionMessage<TException> where TException : Exception
{
    /// <summary>
    /// Creates the message for the specified exception.
    /// </summary>
    /// <param name="exception">The exception for which to generate the message.</param>
    /// <returns>A string representing the message for the exception.</returns>
    public string For(TException exception);
}