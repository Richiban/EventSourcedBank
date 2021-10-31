namespace EventSourcedBank.Domain
{
    public sealed record FundsWithdrawn(
        AccountId AppliesTo,
        EventId Id,
        EventDateTime OccurredOn,
        Money AmountWithdrawn) : BankAccountEvent(AppliesTo, Id, OccurredOn)
    {
        public override BankAccountState ApplyTo(BankAccountState state) =>
            state with { CurrentBalance = state.CurrentBalance - AmountWithdrawn };
    }
}