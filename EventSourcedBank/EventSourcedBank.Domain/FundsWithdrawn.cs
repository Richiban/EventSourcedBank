using System;

namespace EventSourcedBank.Domain
{
    public sealed class FundsWithdrawn : BankAccountEvent
    {
        public FundsWithdrawn(int id, DateTimeOffset occuredOn, Money amount) : base(id, occuredOn)
        {
            AmountWithdrawn = amount;
        }

        public Money AmountWithdrawn { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
            => new BankAccountState(state.CurrentBalance - AmountWithdrawn);
    }
}