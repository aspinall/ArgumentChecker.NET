using System;
using System.Collections;

namespace Aspinall.ArgumentChecker
{
    /// <summary>
    /// Provides a succinct way to check argument preconditions and throw meaningful exceptions if those preconditions are not met.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be checked.</typeparam>
    public class ArgumentChecker<T>
    {
        /// <summary>
        /// The value passed to the <see cref="ArgumentChecker{T}.ArgumentChecker(T, string)"/> constructor.
        /// </summary>
        /// <example>
        /// You can use this to assert and assign the value on a single line:
        /// <code>
        /// public string MyValue { get; }
        /// 
        /// public MyClass(string myArgument)
        /// {
        ///     MyValue = new ArgumentChecker(myArgument, nameof(myArgument)).IsNotNull().Value;
        /// }
        /// </code>
        /// This can be made more fluent and succinct using <see cref="FluentChecker"/>.
        /// </example>       
        public T Value { get; }

        private string Name;

        /// <summary>
        /// Creates a new <see cref="ArgumentChecker{T}"/>.
        /// </summary>
        /// <param name="argument">The argument to be checked.</param>
        /// <param name="name">The name of the argument to be checked. Used in <c>Exception</c> messages.</param>
        public ArgumentChecker(T argument, string name)
        {
            Value = argument;
            Name = name;
        }

        /// <summary>
        /// Checks that <see cref="Value"/> is equal to <paramref name="expectedValue"/> and throws an <see cref="ArgumentException"/> if it does not.
        /// </summary>
        /// <param name="expectedValue">The expected value of <see cref="Value"/>.</param>
        /// <returns><c>self</c></returns>
        /// <exception cref="ArgumentException">Thrown when <see cref="Value"/> does not equal <paramref name="expectedValue"/>.</exception>
        public ArgumentChecker<T> IsEqualTo(T expectedValue)
        {
            if (!Value.Equals(expectedValue))
            {
                throw new ArgumentException($"{Name} must equal {expectedValue.ToString()}");
            }
            return this;
        }

        /// <summary>
        /// Checks that <see cref="Value"/> is not the default value for it's type.
        /// </summary>
        /// <returns><c>self</c></returns>
        /// <exception cref="ArgumentException">Thrown when <see cref="Value"/> is the default value for its type.</exception>
        public ArgumentChecker<T> IsNotDefaultValue()
        {
            if (default(T).Equals(Value))
            {
                throw new ArgumentException($"{Name} cannot be the default value for {typeof(T).ToString()}");
            }
            return this;
        }

        /// <summary>
        /// Checks that <see cref="Value"/> is not an empty <see cref="ICollection"/>.
        /// </summary>
        /// <remarks>If <see cref="Value"/> does not implement <see cref="ICollection"/> then no check is performed, no exception is thrown, and <c>self</c> is returned.</remarks>
        /// <returns><c>self</c></returns>
        /// <exception cref="ArgumentException">Thrown if <see cref="Value"/> implements <see cref="ICollection"/> and is an empty collection.</exception>
        public ArgumentChecker<T> IsNotEmpty()
        {
            if (Value is ICollection collection && collection.Count == 0)
            {
                throw new ArgumentException($"{Name} cannot be empty");
            }
            return this;
        }

        /// <summary>
        /// Checks that <see cref="Value"/> is not <c>null</c>.
        /// </summary>
        /// <returns><c>self</c></returns>
        /// <exception cref="ArgumentNullException">Thrown if <see cref="Value"/> is <c>null</c>.</exception>
        public ArgumentChecker<T> IsNotNull()
        {
            if (Value == null)
            {
                throw new ArgumentNullException(Name);
            }
            return this;
        }

        /// <summary>
        /// Checks that a <see cref="string"/> is not <c>null</c>, empty or contains only whitespace characters.
        /// </summary>
        /// <returns><c>self</c></returns>
        /// <exception cref="ArgumentNullException">Thrown if <see cref="Value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <see cref="Value"/> is empty or contains only whitespace characters.</exception>
        public ArgumentChecker<T> IsNotNullOrWhitespace()
        {
            this.IsNotNull();
            if (Value is string && string.IsNullOrWhiteSpace(Value as string))
            {
                throw new ArgumentException($"{Name} cannot be null, empty or whitespace");
            }
            return this;
        }
    }
}