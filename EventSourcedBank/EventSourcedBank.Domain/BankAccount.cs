using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EventSourcedBank.Domain
{
    public sealed class BankAccount : EventStream<BankAccountEvent>
    {
        private EventId GetNextEventId() => new EventId(Events.Count);

        private BankAccount ApplyEvent(BankAccountEvent evt)
            => new BankAccount(Id, Events.Add(evt), evt.ApplyTo(State));

        private BankAccount(AccountId id, ImmutableList<BankAccountEvent> events, BankAccountState state)
            : base(events)
        {
            State = state;
            Id = id;
        }

        public AccountId Id { get; }
        public BankAccountState State { get; }

        public BankAccount Deposit(Money amount, EventDateTime requestedOn)
        {
            return ApplyEvent(new FundsDeposited(GetNextEventId(), requestedOn, amount));
        }

        public BankAccount Withdraw(Money amount, EventDateTime requestedOn)
        {
            var sufficientFunds = State.CurrentBalance >= amount;

            if (!sufficientFunds)
                throw new InsufficientFundsException();

            return ApplyEvent(new FundsWithdrawn(GetNextEventId(), requestedOn, amount));
        }

        public static class Factory
        {
            public static BankAccount OpenNewAccount(AccountId id, EventDateTime eventOn)
                =>
                new BankAccount(
                    id,
                    ImmutableList.Create<BankAccountEvent>(new AccountCreated(default(EventId), eventOn)),
                    InitialState);

            public static BankAccount Restore(AccountId id, IEnumerable<BankAccountEvent> events)
            {
                var initialisedAccount = new BankAccount(
                    id,
                    ImmutableList.Create<BankAccountEvent>(),
                    InitialState);

                return events.Aggregate(initialisedAccount, (account, evt) => account.ApplyEvent(evt));
            }

            private static readonly BankAccountState InitialState = new BankAccountState(
                Money.Zero,
                default(EventDateTime));
        }
    }
}