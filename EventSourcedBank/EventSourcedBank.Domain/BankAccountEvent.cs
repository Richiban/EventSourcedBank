namespace EventSourcedBank.Domain
{
    public abstract class BankAccountEvent : DomainEvent
    {
        public abstract BankAccountState ApplyTo(BankAccountState state);

        protected BankAccountEvent(AccountId appliesTo, EventId id, EventDateTime occuredOn) : base(id, occuredOn)
        {
            AppliesTo = appliesTo;
        }

        public AccountId AppliesTo { get; }
    }
}