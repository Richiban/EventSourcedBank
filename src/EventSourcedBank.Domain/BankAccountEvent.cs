using System;

namespace Richiban.EventSourcedBank.Domain
{
    public abstract record BankAccountEvent(
        AccountId AppliesTo,
        EventId Id,
        EventDateTime OccurredOn) : DomainEvent(Id, OccurredOn)
    {
        public abstract BankAccountState ApplyTo(BankAccountState state);
    }
}