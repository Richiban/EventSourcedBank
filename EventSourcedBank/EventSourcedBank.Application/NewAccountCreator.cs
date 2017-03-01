using System;
using EventSourcedBank.Data.Write;
using EventSourcedBank.Domain;

namespace EventSourcedBank.Application
{
    public sealed class NewAccountCreator
    {
        private readonly IBankAccountRepository _repository;

        public NewAccountCreator(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreateNewAccountCommand command)
        {
            var accountId = new AccountId(command.AccountId);

            var account = BankAccount.Create(accountId, DateTimeOffset.Now);

            _repository.Save(account);
        }
    }
}