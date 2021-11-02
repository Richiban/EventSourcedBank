using System;

namespace Richiban.EventSourcedBank.Domain
{
    public sealed record AccountFrozen(
        AccountId AppliesTo,
        EventId Id,
        EventDateTime OccurredOn) : BankAccountEvent(AppliesTo, Id, OccurredOn)
    {
        public override BankAccountState ApplyTo(BankAccountState state) =>
            state with { IsFrozen = true };
    }
}