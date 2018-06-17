using System;

namespace Solid
{
    public struct Maybe<T> : IEquatable<Maybe<T>>
    {
        public static Maybe<T> None { get; } = default(Maybe<T>);
        public static Maybe<T> Some(T value) => new Maybe<T>(value);

        private readonly T _value;

        public Maybe(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            _value = value;
            HasValue = true;
        }

        public T Value => HasValue ? _value : throw new InvalidCastException($"Unable to access {nameof(Value)} of {nameof(Maybe<T>)}, when no value is set. Always check {nameof(HasValue)} or use the {nameof(GetValueOrDefault)} method.");
        public bool HasValue { get; }

        public static bool operator ==(Maybe<T> m1, Maybe<T> m2)
        {
            if (m1.HasValue != m2.HasValue) return false;
            return !m1.HasValue || m1.Value.Equals(m2.Value);
        }

        public static bool operator !=(Maybe<T> m1, Maybe<T> m2)
        {
            if (m1.HasValue != m2.HasValue) return true;
            return m1.HasValue && !m1.Value.Equals(m2.Value);
        }

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static implicit operator Maybe<T>(Maybe value)
        {
            return None;
        }

        public bool Equals(Maybe<T> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return obj is Maybe<T> m && Equals(m);
        }

        public override int GetHashCode()
        {
            return HasValue ? Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            if (HasValue)
                return $"Some: {Value}";
            else
                return "None";
        }

        public T GetValueOrDefault(T defaultValue = default(T))
        {
            return HasValue ? Value : defaultValue;
        }

        public Maybe<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            if (HasValue)
                return new Maybe<TResult>(selector(Value));
            else
                return new Maybe<TResult>();
        }
    }

    public sealed class Maybe
    {
        private Maybe() { }

        public static Maybe None { get; } = new Maybe();
        public static Maybe<T> Some<T>(T value) => new Maybe<T>(value);
        public static Maybe<T> Some<T>(T? value) where T : struct => value.HasValue ? new Maybe<T>(value.Value) : Maybe<T>.None;
    }
}
