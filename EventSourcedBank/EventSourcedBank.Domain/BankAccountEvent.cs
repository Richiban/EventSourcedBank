namespace EventSourcedBank.Domain
{
    public abstract class BankAccountEvent : DomainEvent
    {
        public abstract BankAccountState ApplyTo(BankAccountState state);
        protected BankAccountEvent(EventId id, EventDateTime occuredOn) : base(id, occuredOn) {}
    }
}