namespace EventSourcedBank.Domain
{
    public sealed class AccountUnfrozen : BankAccountEvent
    {
        public AccountUnfrozen(AccountId appliesTo, EventId id, EventDateTime occuredOn)
            : base(appliesTo, id, occuredOn) {}

        public override BankAccountState ApplyTo(BankAccountState state) => state.WithFrozen(false);
    }
}