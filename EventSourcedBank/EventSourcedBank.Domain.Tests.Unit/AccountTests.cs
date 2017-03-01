using System;
using System.Linq;
using NUnit.Framework;

namespace EventSourcedBank.Domain.Tests.Unit
{
    public sealed class AccountTests
    {
        [Test]
        public void Given_a_new_account_When_I_deposit_50_Then_the_balance_is_50()
        {
            var account = NewAccount(Money.Zero);

            var fiftyMonies = new Money(5000);
            account = account.Deposit(fiftyMonies, DateTimeOffset.Now);

            var actualBalance = account.State.CurrentBalance;
            var expectedBalance = fiftyMonies;

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void Given_an_account_with_a_balance_of_50_When_I_withdraw_50_Then_the_balance_is_0()
        {
            var fiftyMonies = new Money(5000);
            var account = NewAccount(fiftyMonies);

            account = account.Withdraw(fiftyMonies, DateTimeOffset.Now);

            var actualBalance = account.State.CurrentBalance;
            var expectedBalance = Money.Zero;

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void Given_an_account_with_a_balance_of_50_When_I_withdraw_100_Then_an_exception_is_thrown()
        {
            var fiftyMonies = new Money(5000);
            var hundredMonies = new Money(10000);
            var account = NewAccount(fiftyMonies);

            Assert.Throws<InsufficientFundsException>(
                () => account = account.Withdraw(hundredMonies, DateTimeOffset.Now));
        }

        private static BankAccount NewAccount(Money monies)
        {
            var bankAccount = BankAccount.Create(AccountId.NewId(), DateTimeOffset.UtcNow);

            return bankAccount.Deposit(monies, DateTimeOffset.Now);
        }
    }
}