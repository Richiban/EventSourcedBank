namespace EventSourcedBank.Domain
{
    public sealed record FundsDeposited(
        AccountId AppliesTo,
        EventId Id,
        EventDateTime OccuredOn,
        Money AmountDeposited) : BankAccountEvent(AppliesTo, Id, OccuredOn)
    {
        public override BankAccountState ApplyTo(BankAccountState state) =>
            state with { CurrentBalance = AmountDeposited + state.CurrentBalance };
    }
}