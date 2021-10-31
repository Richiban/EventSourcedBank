using System;

namespace EventSourcedBank.Domain
{
    public record Money(int Value)
    {
        public static Money operator +(Money left, Money right) => new (left.Value + right.Value);
        public static Money operator -(Money left, Money right) => new (left.Value - right.Value);
        public static bool operator >(Money left, Money right) => left.Value > right.Value;
        public static bool operator >=(Money left, Money right) => left.Value >= right.Value;
        public static bool operator <(Money left, Money right) => left.Value < right.Value;
        public static bool operator <=(Money left, Money right) => left.Value <= right.Value;

        public static Money Zero { get; } = new (0);
    }
}