using System;
using EventSourcedBank.Domain;
using NUnit.Framework;
using static PowerAssert.PAssert;

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

            var createdDate = GetUtcNow();

            var bankAccount = BankAccount.Factory.OpenNewAccount(id, createdDate)
                .Deposit(startingBalance, createdDate);
            
            IsTrue(() => bankAccount.State.CurrentBalance == startingBalance);

            return bankAccount;
        }

        private static EventDateTime GetUtcNow() => new EventDateTime(DateTimeOffset.UtcNow);

        public void AssertSame(BankAccount original, BankAccount toCompare)
        {
            Assert.That(toCompare.Id, Is.EqualTo(original.Id));
            Assert.That(toCompare.State.CurrentBalance, Is.EqualTo(original.State.CurrentBalance));
        }
    }
}