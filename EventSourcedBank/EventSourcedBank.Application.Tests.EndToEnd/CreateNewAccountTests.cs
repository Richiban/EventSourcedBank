using System;
using System.Runtime.InteropServices;
using EventSourcedBank.Data.Write;
using FluentAssertions;
using NUnit.Framework;

namespace EventSourcedBank.Application.Tests.EndToEnd
{
    [TestFixture]
    public class CreateNewAccountTests
    {
        private NewAccountCreator _newAccountCreator;
        private AccountRetriever _accountRetriever;

        [SetUp]
        public void SetUp()
        {
            _newAccountCreator = new NewAccountCreator(new BankAccountRepository());
            _accountRetriever = new AccountRetriever();
        }

        /// <summary>
        /// Given nothing
        /// When I create a new account
        /// Then I can retrieve the state of the account
        /// </summary>
        [Test]
        public void Given_When_Then()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);

            _newAccountCreator.Create(command);

            var actual = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));

            actual.Id.Should().Be(accountId);
            actual.Balance.Should().Be(0);
        }
    }
}