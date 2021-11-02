using System;
using Richiban.EventSourcedBank.Data.Write;
using Richiban.EventSourcedBank.Domain;

namespace Richiban.EventSourcedBank.Application
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

            _accountRepository.Save(account.Deposit(amountToDeposit, GetNow()));
        }

        public void Withdraw(MakeWithdrawalCommand makeWithdrawalCommand)
        {
            var amountToWithdraw = new Money(makeWithdrawalCommand.AmountInPence);
            var accountId = new AccountId(makeWithdrawalCommand.AccountId);

            try
            {
                var account = _accountRepository.Retrieve(accountId);

                _accountRepository.Save(account.Withdraw(amountToWithdraw, GetNow()));
            }
            catch (Domain.AccountIsFrozenException)
            {
                throw new Application.AccountIsFrozenException();
            }
        }

        private EventDateTime GetNow() => new EventDateTime(DateTimeOffset.Now);
    }
}