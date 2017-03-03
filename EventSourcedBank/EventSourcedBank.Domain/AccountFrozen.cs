namespace EventSourcedBank.Domain
{
    public sealed class AccountFrozen : BankAccountEvent
    {
        public AccountFrozen(EventId id, EventDateTime occuredOn) : base(id, occuredOn) {}

        public override BankAccountState ApplyTo(BankAccountState state) => state.WithFrozen(true);
    }
}