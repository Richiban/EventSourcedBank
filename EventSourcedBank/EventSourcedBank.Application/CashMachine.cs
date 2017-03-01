using System;
using EventSourcedBank.Data.Write;
using EventSourcedBank.Domain;

namespace EventSourcedBank.Application
{
    public sealed class CashMachine
    {
        private readonly IBankAccountRepository _accountRepository;

        public CashMachine(IBankAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Deposit(MakeDepositCommand makeDepositCommand)
        {
            var amountToDeposit = new Money(makeDepositCommand.AmountInPence);
            var accountId = new AccountId(makeDepositCommand.AccountId);

            var account = _accountRepository.Retrieve(accountId);

            _accountRepository.Save(account.Deposit(amountToDeposit, DateTimeOffset.Now));
        }

        public void Withdraw(MakeWithdrawalCommand makeWithdrawalCommand)
        {
            var amountToWithdraw = new Money(makeWithdrawalCommand.AmountInPence);
            var accountId = new AccountId(makeWithdrawalCommand.AccountId);

            var account = _accountRepository.Retrieve(accountId);

            _accountRepository.Save(account.Withdraw(amountToWithdraw, DateTimeOffset.Now));
        }
    }
}