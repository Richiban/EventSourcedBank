using System;

namespace EventSourcedBank.Domain
{
    public abstract class BankAccountEvent : DomainEvent
    {
        public abstract BankAccountState ApplyTo(BankAccountState state);
        protected BankAccountEvent(int id, DateTimeOffset occuredOn) : base(id, occuredOn) {}
    }
}