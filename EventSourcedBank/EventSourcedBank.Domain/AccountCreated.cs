using System;

namespace EventSourcedBank.Domain
{
    public sealed class AccountCreated : BankAccountEvent
    {
        public AccountCreated(DateTimeOffset createdOn)
        {
            CreatedOn = createdOn;
        }

        public override BankAccountState ApplyTo(BankAccountState state) => state;

        public DateTimeOffset CreatedOn { get; }
    }
}