using System;
using EventSourcedBank.Domain;
using NUnit.Framework;
using static PowerAssert.PAssert;
using Newtonsoft.Json;

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
        public void When_I_save_a_bank_account_Then_I_can_retrieve_it()
        {
            var id = AccountId.NewId();
            var original = GetBankAccount(id);

            _bankAccountRepository.Save(original);
            var retrieved = _bankAccountRepository.Retrieve(id);

            AssertSame(original, retrieved);
        }

        private static BankAccount GetBankAccount(AccountId id)
        {
            var startingBalance = new Money(5000);

            var createdDate = GetUtcNow();

            var bankAccount = BankAccount.Factory.OpenNewAccount(id, createdDate);
            
            //IsTrue(() => bankAccount.State.CurrentBalance == startingBalance);

            return bankAccount;
        }

        private static EventDateTime GetUtcNow() => new EventDateTime(DateTimeOffset.UtcNow);

        public void AssertSame(BankAccount original, BankAccount toCompare)
        {
            var left = JsonConvert.SerializeObject(original);
            var right = JsonConvert.SerializeObject(toCompare);

            IsTrue(() => left == right);
        }
    }
}