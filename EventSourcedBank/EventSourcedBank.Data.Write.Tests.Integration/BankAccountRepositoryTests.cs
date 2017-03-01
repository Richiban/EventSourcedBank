using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcedBank.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace EventSourcedBank.Data.Write.Tests.Integration
{
    [TestFixture]
    public class BankAccountRepositoryTests
    {
        private BankAccountRepository _bankAccountRepository;

        [SetUp]
        public void SetUp()
        {
            _bankAccountRepository = new BankAccountRepository();
        }

        [Test]
        public void Given_When_Then()
        {
            var id = AccountId.NewId();
            var original = GetBankAccount(id);

            _bankAccountRepository.Save(original);
            var retrieved = _bankAccountRepository.Retrieve(original.Id);

            AssertSame(original, retrieved);
        }

        private static BankAccount GetBankAccount(AccountId id)
        {
            var startingBalance = new Money(5000);

            var bankAccount = BankAccount.Create(id, DateTimeOffset.UtcNow).Deposit(startingBalance, DateTimeOffset.Now);

            bankAccount.State.CurrentBalance.Should().Be(startingBalance);

            return bankAccount;
        }

        public void AssertSame(BankAccount original, BankAccount toCompare)
        {
            Assert.That(toCompare.Id, Is.EqualTo(original.Id));
            Assert.That(toCompare.State.CurrentBalance, Is.EqualTo(original.State.CurrentBalance));
        }
    }
}