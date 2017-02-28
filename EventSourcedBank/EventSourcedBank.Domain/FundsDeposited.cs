namespace EventSourcedBank.Domain
{
    public sealed class FundsDeposited : BankAccountEvent
    {
        public FundsDeposited(Money amount)
        {
            AmountDeposited = amount;
        }

        public Money AmountDeposited { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
        {
            var newBalance = AmountDeposited + state.CurrentBalance;

            return new BankAccountState(newBalance);
        }
    }
}