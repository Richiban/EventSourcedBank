namespace EventSourcedBank.Domain
{
    public struct Money
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

        public override bool Equals(object other) => Equals((Money)other);
        public bool Equals(Money other) => other.Value == Value;
        public override int GetHashCode() => Value;

        public static Money Zero { get; } = new Money();
    }
}