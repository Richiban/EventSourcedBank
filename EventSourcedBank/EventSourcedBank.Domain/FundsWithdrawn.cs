namespace EventSourcedBank.Domain
{
    public sealed class FundsWithdrawn : BankAccountEvent
    {
        public FundsWithdrawn(Money amount)
        {
            AmountWithdrawn = amount;
        }

        public Money AmountWithdrawn { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
            => new BankAccountState(state.CurrentBalance - AmountWithdrawn);
    }
}