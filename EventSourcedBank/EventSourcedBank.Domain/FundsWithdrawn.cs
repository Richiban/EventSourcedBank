using System;

namespace EventSourcedBank.Domain
{
    public sealed class FundsWithdrawn : BankAccountEvent
    {
        public FundsWithdrawn(EventId id, EventDateTime occuredOn, Money amount) : base(id, occuredOn)
        {
            AmountWithdrawn = amount;
        }

        public Money AmountWithdrawn { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
            => state.WithBalance(state.CurrentBalance - AmountWithdrawn);
    }
}