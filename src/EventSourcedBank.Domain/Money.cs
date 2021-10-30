using System;

namespace EventSourcedBank.Domain
{
    public struct Money : IEquatable<Money>
    {
        public Money(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Money operator +(Money left, Money right) => new Money(left.Value + right.Value);
        public static Money operator -(Money left, Money right) => new Money(left.Value - right.Value);
        public static bool operator >(Money left, Money right) => left.Value > right.Value;
        public static bool operator >=(Money left, Money right) => left.Value >= right.Value;
        public static bool operator <(Money left, Money right) => left.Value < right.Value;
        public static bool operator <=(Money left, Money right) => left.Value <= right.Value;
        public static bool operator ==(Money left, Money right) => left.Value == right.Value;
        public static bool operator !=(Money left, Money right) => left.Value != right.Value;

        public override bool Equals(object? other) =>
            other switch
            {
                Money m => Equals(m),
                _ => false
            };

        public bool Equals(Money other) => other.Value == Value;
        public override int GetHashCode() => Value;

        public static Money Zero { get; } = new (0);
    }
}