using System;

namespace EventSourcedBank.Domain
{
    public sealed class FundsDeposited : BankAccountEvent
    {
        public FundsDeposited(int id, DateTimeOffset occuredOn, Money amount) : base(id, occuredOn)
        {
            AmountDeposited = amount;
        }

        public Money AmountDeposited { get; }

        public override BankAccountState ApplyTo(BankAccountState state)
        {
            var newBalance = AmountDeposited + state.CurrentBalance;

            return new BankAccountState(newBalance);
        }
    }
}