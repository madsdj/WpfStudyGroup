using System;
using System.Collections;
using System.Collections.Generic;

namespace Solid
{
    public struct Maybe<T> : IMaybe, IEquatable<Maybe<T>>, IEnumerable<T>
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

        object IMaybe.Value => Value;

        public T Value => HasValue ? _value : throw new InvalidCastException($"Unable to access {nameof(Value)} of {nameof(Maybe<T>)}, when no value is set. Always check {nameof(HasValue)} or use the {nameof(GetValueOrDefault)} method.");
        public bool HasValue { get; }

        public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);
        public static implicit operator Maybe<T>(Maybe value) => None;

        public static bool operator ==(Maybe<T> m1, Maybe<T> m2)
        {
            if (m1.HasValue != m2.HasValue) return false;
            return !m1.HasValue || EqualityComparer<T>.Default.Equals(m1.Value, m2.Value);
        }

        public static bool operator !=(Maybe<T> m1, Maybe<T> m2)
        {
            if (m1.HasValue != m2.HasValue) return true;
            return m1.HasValue && !EqualityComparer<T>.Default.Equals(m1.Value, m2.Value);
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
            return HasValue ? $"Some: {Value}" : "None";
        }

        public T GetValueOrDefault(T defaultValue = default(T))
        {
            return HasValue ? Value : defaultValue;
        }

        public Maybe<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            if (HasValue)
                return new Maybe<TResult>(selector(Value));
            else
                return new Maybe<TResult>();
        }

        public Maybe<TResult> Cast<TResult>()
        {
            if (HasValue)
                return Maybe<TResult>.Some((TResult)(object)Value);
            else
                return Maybe<TResult>.None;
        }

        public Maybe<TResult> OfType<TResult>()
        {
            if (HasValue && Value is TResult)
                return Maybe<TResult>.Some((TResult)(object)Value);
            else
                return Maybe<TResult>.None;
        }

        public TResult Match<TResult>(Func<T, TResult> some, TResult none)
        {
            if (some == null) throw new ArgumentNullException(nameof(some));
            return HasValue ? some(Value) : none;
        }

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            if (some == null) throw new ArgumentNullException(nameof(some));
            if (none == null) throw new ArgumentNullException(nameof(none));
            return HasValue ? some(Value) : none();
        }

        public void Match(Action<T> some, Action none)
        {
            if (some == null) throw new ArgumentNullException(nameof(some));
            if (none == null) throw new ArgumentNullException(nameof(none));

            if (HasValue)
                some(Value);
            else
                none();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (HasValue) yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (HasValue) yield return Value;
        }
    }

    public sealed class Maybe
    {
        private Maybe() { }

        public static Maybe None { get; } = new Maybe();
        public static Maybe<T> Some<T>(T value) => new Maybe<T>(value);
        public static Maybe<T> Some<T>(T? value) where T : struct => value.HasValue ? new Maybe<T>(value.Value) : Maybe<T>.None;
        public static Maybe<T> NoneIfNull<T>(T value) where T : class => value is null ? Maybe<T>.None : new Maybe<T>(value);
        public static Maybe<T> NoneIfNull<T>(T? value) where T : struct => value is null ? Maybe<T>.None : new Maybe<T>(value.Value);
    }
}
