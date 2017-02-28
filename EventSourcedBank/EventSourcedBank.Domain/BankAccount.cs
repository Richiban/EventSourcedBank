using System.Collections.Generic;

namespace EventSourcedBank.Domain
{
    public sealed class BankAccount : EventStream<BankAccountEvent>
    {
        private BankAccount ApplyEvent(BankAccountEvent evt) => new BankAccount(Events.Add(evt), evt.ApplyTo(State));

        public BankAccount(IEnumerable<BankAccountEvent> events, BankAccountState state) : base(events)
        {
            State = state;
        }

        public BankAccount Deposit(Money amount) => ApplyEvent(new FundsDeposited(amount));
        public BankAccount Withdraw(Money amount)
        {
            bool sufficientFunds = State.CurrentBalance >= amount;

            if (!sufficientFunds)
                throw new InsufficientFundsException();

            return ApplyEvent(new FundsWithdrawn(amount));
        }

        public BankAccountState State { get; }
    }
}