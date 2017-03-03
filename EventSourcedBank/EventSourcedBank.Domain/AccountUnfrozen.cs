namespace EventSourcedBank.Domain
{
    public sealed class AccountUnfrozen : BankAccountEvent
    {
        public AccountUnfrozen(EventId id, EventDateTime occuredOn) : base(id, occuredOn) {}

        public override BankAccountState ApplyTo(BankAccountState state) => state.WithFrozen(false);
    }
}