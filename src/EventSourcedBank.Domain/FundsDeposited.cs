namespace EventSourcedBank.Domain
{
    public sealed record FundsDeposited(
        AccountId AppliesTo,
        EventId Id,
        EventDateTime OccurredOn,
        Money AmountDeposited) : BankAccountEvent(AppliesTo, Id, OccurredOn)
    {
        public override BankAccountState ApplyTo(BankAccountState state) =>
            state with { CurrentBalance = AmountDeposited + state.CurrentBalance };
    }
}