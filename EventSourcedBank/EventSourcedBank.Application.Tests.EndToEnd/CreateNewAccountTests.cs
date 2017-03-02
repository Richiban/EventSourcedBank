using System;
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
        private CashMachine _cashMachine;

        [SetUp]
        public void SetUp()
        {
            var bankAccountRepository = new BankAccountRepository();
            var clock = new Clock();

            _newAccountCreator = new NewAccountCreator(bankAccountRepository, clock);
            _accountRetriever = new AccountRetriever();
            _cashMachine = new CashMachine(bankAccountRepository);
        }

        /// <summary>
        /// When I create a new account
        /// Then I can retrieve the state of the account
        /// </summary>
        [Test]
        public void Test1()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);

            _newAccountCreator.Create(command);

            var actual = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));

            actual.Id.Should().Be(accountId);
            actual.Balance.Should().Be(0);
        }

        /// <summary>
        /// Given a new account
        /// When I deposit 50
        /// Then my balance is 50
        /// </summary>
        [Test]
        public void Test2()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);
            _newAccountCreator.Create(command);

            _cashMachine.Deposit(new MakeDepositCommand(accountId, 5000));

            var actual = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));

            actual.Id.Should().Be(accountId);
            actual.Balance.Should().Be(5000);
        }

        /// <summary>
        /// Given a new account with balance 50
        /// When I withdraw 20
        /// Then my balance is 30
        /// </summary>
        [Test]
        public void Test3()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);
            _newAccountCreator.Create(command);

            _cashMachine.Deposit(new MakeDepositCommand(accountId, 5000));

            _cashMachine.Withdraw(new MakeWithdrawalCommand(accountId, 2000));

            var actual = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));

            actual.Id.Should().Be(accountId);
            actual.Balance.Should().Be(3000);
        }
    }
}