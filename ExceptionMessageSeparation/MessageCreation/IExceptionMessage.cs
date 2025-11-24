namespace ExceptionMessageSeparation.MessageCreation;

/// <summary>
/// Defines a contract for creating exception messages.
/// </summary>
/// <typeparam name="TContext">The type of the exception that this interface applies to.</typeparam>
/// <remarks>
/// The <typeparamref name="TContext"/> type specified in this interface 
/// should implement the <see cref="IHaveMessage{TMessage}"/> interface, 
/// where the generic type argument <typeparamref name="TMessage"/> can be:
/// <para>- the same as the type implementing this interface</para>
/// <para>- a base type of the type implementing this interface</para> 
/// </remarks> 
public interface IExceptionMessage<TContext>
{
    /// <summary>
    /// Creates the message for the specified exception.
    /// </summary>
    /// <param name="context">The exception for which to generate the message.</param>
    /// <returns>A string representing the message for the exception.</returns>
    public string For(IMessageCreationContext<TContext> context);
}