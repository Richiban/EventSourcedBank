using System;
using System.Security.Policy;
using EventSourcedBank.Data.Write;
using EventSourcedBank.Domain;

namespace EventSourcedBank.Application
{
    public sealed class CustomerServiceRepresentative
    {
        private readonly IBankAccountRepository _accountRepository;
        private readonly IClock _clock;

        public CustomerServiceRepresentative(IBankAccountRepository accountRepository, IClock clock)
        {
            _accountRepository = accountRepository;
            _clock = clock;
        }

        public void FreezeAccount(FreezeAccountCommand command)
        {
            var account = _accountRepository.Retrieve(new AccountId(command.AccountId));

            var bankAccount = account.Freeze(GetNow());

            _accountRepository.Save(bankAccount);
        }

        public void UnfreezeAccount(UnfreezeAccountCommand command)
        {
            var account = _accountRepository.Retrieve(new AccountId(command.AccountId));

            var bankAccount = account.UnFreeze(GetNow());

            _accountRepository.Save(bankAccount);
        }

        private EventDateTime GetNow() => new EventDateTime(_clock.Now);
    }
}