namespace EventSourcedBank.Domain
{
    public struct Money
    {
        public Money(int value)
        {
            Value = value;
            DecimalValue = (decimal) value / 100m;
        }

        public int Value { get; }
        public decimal DecimalValue { get; }
        public override string ToString() => DecimalValue.ToString("C");

        public static Money operator +(Money left, Money right) => new Money(left.Value + right.Value);
        public static Money operator -(Money left, Money right) => new Money(left.Value - right.Value);
        public static bool operator >(Money left, Money right) => left.Value > right.Value;
        public static bool operator >=(Money left, Money right) => left.Value >= right.Value;
        public static bool operator <(Money left, Money right) => left.Value < right.Value;
        public static bool operator <=(Money left, Money right) => left.Value <= right.Value;

        public static Money Zero { get; } = new Money();
    }
}