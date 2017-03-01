using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSourcedBank.Domain
{
    public sealed class BankAccount : EventStream<BankAccountEvent>
    {
        private static readonly BankAccountState InitialState = new BankAccountState(Money.Zero);

        private BankAccount ApplyEvent(BankAccountEvent evt)
            => new BankAccount(Id, Events.Add(evt), evt.ApplyTo(State));

        private BankAccount(AccountId id, IEnumerable<BankAccountEvent> events, BankAccountState state)
            : base(events)
        {
            State = state;
            Id = id;
        }

        public BankAccount Deposit(Money amount, DateTimeOffset requestedOn)
            => ApplyEvent(new FundsDeposited(GetNextEventId(), requestedOn, amount));

        private int GetNextEventId() => Events.Count;

        public BankAccount Withdraw(Money amount, DateTimeOffset requestedOn)
        {
            var sufficientFunds = State.CurrentBalance >= amount;

            if (!sufficientFunds)
                throw new InsufficientFundsException();

            return ApplyEvent(new FundsWithdrawn(GetNextEventId(), requestedOn, amount));
        }

        public static BankAccount Create(AccountId id, DateTimeOffset createdOn)
            => new BankAccount(id, new[] { new AccountCreated(id: 0, createdOn: createdOn) }, InitialState);

        public static BankAccount Restore(AccountId id, IEnumerable<BankAccountEvent> events)
        {
            var initialisedAccount = new BankAccount(id, Enumerable.Empty<BankAccountEvent>(), InitialState);

            return events.Aggregate(initialisedAccount, (account, evt) => account.ApplyEvent(evt));
        }

        public BankAccountState State { get; }
        public AccountId Id { get; }
    }
}