namespace EventSourcedBank.Domain
{
    public sealed class AccountCreated : BankAccountEvent
    {
        public AccountCreated(AccountId appliesTo, EventId id, EventDateTime occurredOn)
            : base(appliesTo,  id, occurredOn)
        {
        }

        public override BankAccountState ApplyTo(BankAccountState state) => state;
    }
}