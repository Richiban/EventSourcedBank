namespace EventSourcedBank.Domain
{
    public sealed class AccountFrozen : BankAccountEvent
    {
        public AccountFrozen(AccountId appliesTo, EventId id, EventDateTime occuredOn) 
            : base(appliesTo, id, occuredOn) {}

        public override BankAccountState ApplyTo(BankAccountState state) => state.WithFrozen(true);
    }
}