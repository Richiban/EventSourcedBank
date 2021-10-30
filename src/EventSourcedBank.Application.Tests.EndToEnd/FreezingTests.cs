using System;
using EventSourcedBank.Data.Write;
using NUnit.Framework;
using static PowerAssert.PAssert;

namespace EventSourcedBank.Application.Tests.EndToEnd
{
    [TestFixture]
    public sealed class FreezingTests
    {
        private NewAccountCreator _newAccountCreator;
        private AccountRetriever _accountRetriever;
        private CashMachine _cashMachine;
        private CustomerServiceRepresentative _customerServiceRepresentative;

        [SetUp]
        public void SetUp()
        {
            var bankAccountRepository = new BankAccountRepository();
            var clock = new Clock();

            _newAccountCreator = new NewAccountCreator(bankAccountRepository, clock);
            _accountRetriever = new AccountRetriever();
            _cashMachine = new CashMachine(bankAccountRepository);
            _customerServiceRepresentative = new CustomerServiceRepresentative(bankAccountRepository, clock);
        }

        /// <summary>
        /// Given a new account
        /// When I freeze my account
        /// Then my account is frozen
        /// </summary>
        [Test]
        public void AccountBeginsAsUnfrozenTest()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);
            _newAccountCreator.Create(command);

            var bankAccountData = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));

            IsTrue(() => bankAccountData.IsFrozen == false);
        }

        /// <summary>
        /// Given a new account
        /// When I freeze my account
        /// Then my account is frozen
        /// </summary>
        [Test]
        public void FreezeAccountTest()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);
            _newAccountCreator.Create(command);

            _customerServiceRepresentative.FreezeAccount(new FreezeAccountCommand(accountId));

            var bankAccountData = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));

            IsTrue(() => bankAccountData.IsFrozen);
        }

        /// <summary>
        /// Given a new account
        /// When I freeze my account
        /// And I unfreeze my account
        /// Then my account is unfrozen
        /// </summary>
        [Test]
        public void UnfreezeAccountTest()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);
            _newAccountCreator.Create(command);

            _customerServiceRepresentative.FreezeAccount(new FreezeAccountCommand(accountId));

            var bankAccountDataBeforeUnfreezing = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));
            _customerServiceRepresentative.UnfreezeAccount(new UnfreezeAccountCommand(accountId));
            var bankAccountDataAfterUnfreezing = _accountRetriever.Retrieve(new BankAccountStateQuery(accountId));

            IsTrue(() => bankAccountDataBeforeUnfreezing.IsFrozen);
            IsTrue(() => bankAccountDataAfterUnfreezing.IsFrozen == false);
        }

        /// <summary>
        /// Given a new account
        /// And I have frozen my account
        /// When I try to withdraw money
        /// Then an Exception is thrown
        /// </summary>
        [Test]
        public void FreezeAccountWithdrawalTest()
        {
            var accountId = Guid.NewGuid();

            var command = new CreateNewAccountCommand(accountId);
            _newAccountCreator.Create(command);

            _cashMachine.Deposit(new MakeDepositCommand(accountId, 5000));

            _customerServiceRepresentative.FreezeAccount(new FreezeAccountCommand(accountId));

            Assert.Throws<AccountIsFrozenException>(
                () => { _cashMachine.Withdraw(new MakeWithdrawalCommand(accountId, 2000)); });
        }
    }
}