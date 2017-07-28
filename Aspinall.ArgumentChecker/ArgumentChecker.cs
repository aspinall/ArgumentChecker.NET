using System;
using System.Collections;

namespace Aspinall.ArgumentChecker
{
    public class ArgumentChecker<T>
    {
        public T Value { get; }

        private string Name;

        public ArgumentChecker(T argument, string name)
        {
            Value = argument;
            Name = name;
        }

        public ArgumentChecker<T> IsEqualTo(T expectedValue)
        {
            if (!Value.Equals(expectedValue))
            {
                throw new ArgumentException($"{Name} must equal {expectedValue.ToString()}");
            }
            return this;
        }

        public ArgumentChecker<T> IsNotDefaultValue()
        {
            if (Value.Equals(default(T)))
            {
                throw new ArgumentException($"{Name} cannot be the default value for {typeof(T).ToString()}");
            }
            return this;
        }

        public ArgumentChecker<T> IsNotEmpty()
        {
            if (Value is ICollection collection && collection.Count == 0)
            {
                throw new ArgumentException($"{Name} cannot be empty");
            }
            return this;
        }

        public ArgumentChecker<T> IsNotNull()
        {
            if (Value == null)
            {
                throw new ArgumentNullException(Name);
            }
            return this;
        }

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