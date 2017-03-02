namespace EventSourcedBank.Domain
{
    public sealed class AccountCreated : BankAccountEvent
    {
        public AccountCreated(EventId id, EventDateTime eventOn) : base(id, eventOn)
        {
            EventOn = eventOn;
        }

        public override BankAccountState ApplyTo(BankAccountState state) => state;

        public EventDateTime EventOn { get; }
    }
}