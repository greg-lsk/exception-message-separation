namespace ExceptionMessageSeparation;

/// <summary>
/// Represents a contract for custom exception types that have a standart messaging logic.
/// </summary>
/// <typeparam name="TMessage">The type of message that this exception will produce</typeparam>
/// <remarks>
/// The <typeparamref name="TMessage"/> type specified in this interface 
/// should implement the <see cref="IExceptionMessage{TException}"/> interface, 
/// where the generic type argument <typeparamref name="TException"/> can be:
/// <para>- the same as the type implementing this interface</para>
/// <para>- a base type of the type implementing this interface</para> 
/// </remarks> 
public interface IHaveMessage<TMessage> where TMessage : new();