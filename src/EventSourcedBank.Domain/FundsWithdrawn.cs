using System;

namespace EventSourcedBank.Domain
{
    public sealed class FundsWithdrawn : BankAccountEvent
    {
        public FundsWithdrawn(AccountId appliesTo, EventId id, EventDateTime occuredOn, Money amount)
            : base(appliesTo, id, occuredOn)
        {
            AmountWithdrawn = amount;
        }

        public Money AmountWithdrawn { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
            => state.WithBalance(state.CurrentBalance - AmountWithdrawn);
    }
}