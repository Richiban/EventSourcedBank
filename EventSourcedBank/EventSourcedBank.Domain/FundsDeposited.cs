namespace EventSourcedBank.Domain
{
    public sealed class FundsDeposited : BankAccountEvent
    {
        public FundsDeposited(EventId id, EventDateTime occuredOn, Money amount) : base(id, occuredOn)
        {
            AmountDeposited = amount;
        }

        public Money AmountDeposited { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
            => state.WithBalance(AmountDeposited + state.CurrentBalance);
    }
}