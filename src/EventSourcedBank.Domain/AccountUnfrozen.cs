namespace EventSourcedBank.Domain
{
    public sealed record AccountUnfrozen(
        AccountId AppliesTo,
        EventId Id,
        EventDateTime OccurredOn) : BankAccountEvent(AppliesTo, Id, OccurredOn)
    {
        public override BankAccountState ApplyTo(BankAccountState state) =>
            state with { IsFrozen = false };
    }
}