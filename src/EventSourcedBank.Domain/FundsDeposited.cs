namespace EventSourcedBank.Domain
{
    public sealed class FundsDeposited : BankAccountEvent
    {
        public FundsDeposited(AccountId appliesTo, EventId id, EventDateTime occuredOn, Money amount) 
            : base(appliesTo, id, occuredOn)
        {
            AmountDeposited = amount;
        }

        public Money AmountDeposited { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
            => state.WithBalance(AmountDeposited + state.CurrentBalance);
    }
}