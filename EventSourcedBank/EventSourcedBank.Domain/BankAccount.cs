using System;
using System.Collections.Generic;

namespace EventSourcedBank.Domain
{
    public sealed class BankAccount : EventStream<BankAccountEvent>
    {
        private BankAccount ApplyEvent(BankAccountEvent evt) => new BankAccount(Id, Events.Add(evt), evt.ApplyTo(State));

        public BankAccount(AccountId id, IEnumerable<BankAccountEvent> events, BankAccountState state) : base(events)
        {
            State = state;
            Id = id;
        }

        public BankAccount Deposit(Money amount) => ApplyEvent(new FundsDeposited(amount));
        public BankAccount Withdraw(Money amount)
        {
            var sufficientFunds = State.CurrentBalance >= amount;

            if (!sufficientFunds)
                throw new InsufficientFundsException();

            return ApplyEvent(new FundsWithdrawn(amount));
        }
        public static BankAccount Create(AccountId id, DateTimeOffset createdOn) => 
            new BankAccount(id, new [] { new AccountCreated(createdOn) }, new BankAccountState(Money.Zero));

        public BankAccountState State { get; }
        public AccountId Id { get; }
    }
}