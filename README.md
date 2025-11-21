## usage with ExceptionBase<,> class (type safety)

### 1. create a *struct* that implements the IExceptionMessage<> interface
```csharp
public readonly struct CustomExceptionMessage : IExceptionMessage<CustomException>
{
    public string For(CustomException exception)
    {
        return $"{exception.SomeIntValue}";
    }
}
```

### 2. create a *class* that inherts from ExceptionBase<,>
```csharp
public class CustomException : ExceptionBase<CustomException, CustomExceptionMessage>
{
    public int SomeIntValue { get; }

    public CustomException(int value, Exception? inner = default) : base(inner)
    {
        SomeIntValue = value;
    }
}
```

### 3. Done

### 4. Remarks
**a. cross type usage:** The _ExceptionBase<,>_ requires the message type tied to its child class, ensuring type safety. This design guarantees that each custom exception class utilizes an appropriate message.

**b. struct initialization:** The _structs_ implementing the _IExceptionMessage<>_ interface uses the default constructor to initialize its state. **As a result, any state that relies on initialization beyond the default constructor is not considered.**


## usage without ExceptionBase<,> class

### 1. create a *struct* that implements the IExceptionMessage<> interface
```csharp
public readonly struct CustomExceptionMessage : IExceptionMessage<CustomException>
{
    public string For(CustomException exception)
    {
        return $"{exception.SomeIntValue}";
    }
}
```

### 2. create a *class* that inherts from Exception
```csharp
public class CustomException : Exception
{
    public int SomeIntValue { get; }

    public override string Message => new CustomExceptionMessage().For(this);

    public CustomException(int value, Exception? inner = default) : base(string.empty, inner)
    {
        SomeIntValue = value;
    }
}
```