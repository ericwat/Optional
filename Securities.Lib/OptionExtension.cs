namespace Securities.Lib;


/// <summary>
/// Represents a value that may or may not be present.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Option<T>
{
    // Factory method to create a Some option
    public static Option<T> Some(T value) => new SomeOption(value);

    // Singleton instance for None option
    public static Option<T> None { get; } = new NoneOption();

    // Private constructor ensures external classes cannot inherit this directly
    private Option()
    {
    }

    // Method to check if the option has a value
    public abstract bool IsSome { get; }

    // Method to get the value, should only be called if IsSome is true
    public abstract T Value { get; }

    // Nested class for representing the presence of a value
    private class SomeOption : Option<T>
    {
        private readonly T _value;

        public SomeOption(T value)
        {
            _value = value;
        }

        public override bool IsSome => true;

        public override T Value => _value;
    }

    // Nested class for representing the absence of a value
    private class NoneOption : Option<T>
    {
        public override bool IsSome => false;

        // Accessing Value in None option should throw an exception
        public override T Value => throw new InvalidOperationException("Cannot access the value of a None option.");
    }
}

/// <summary>
/// Extension methods for the Option type.
/// </summary>
public static class OptionExtensions
{
    public static async Task MatchAsync<T>(
        this Option<IEnumerable<T>> option,
        Func<IEnumerable<T>, Task> some,
        Func<Task> none) => await (option.IsSome ? some(option.Value) : none());
}