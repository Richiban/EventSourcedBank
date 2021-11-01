using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EventSourcedBank.Domain
{
    public sealed class BankAccount : EventStream<BankAccountEvent>
    {
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
            if (State.IsFrozen)
                throw new AccountIsFrozenException();

            return ApplyEvent(new FundsDeposited(Id, GetNextEventId(), requestedOn, amount));
        }

        public BankAccount Withdraw(Money amount, EventDateTime requestedOn)
        {
            if (State.IsFrozen)
                throw new AccountIsFrozenException();

            var sufficientFunds = State.CurrentBalance >= amount;

            if (!sufficientFunds)
                throw new InsufficientFundsException();

            return ApplyEvent(new FundsWithdrawn(Id, GetNextEventId(), requestedOn, amount));
        }

        public BankAccount Freeze(EventDateTime requestedOn)
        {
            if (State.IsFrozen)
                return this;

            return ApplyEvent(new AccountFrozen(Id, GetNextEventId(), requestedOn));
        }

        public BankAccount UnFreeze(EventDateTime requestedOn)
        {
            if (State.IsFrozen == false)
                return this;

            return ApplyEvent(new AccountUnfrozen(Id, GetNextEventId(), requestedOn));
        }

        public static class Factory
        {
            public static BankAccount OpenNewAccount(AccountId id, EventDateTime eventOn)
                =>
                new BankAccount(
                    id,
                    ImmutableList.Create<BankAccountEvent>(new AccountCreated(id, EventId.NewId(), eventOn)),
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
                EventDateTime.MinValue,
                IsFrozen: false);
        }
    }
}