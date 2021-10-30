using EventSourcedBank.Data.Write;
using EventSourcedBank.Domain;

namespace EventSourcedBank.Application
{
    public sealed class NewAccountCreator
    {
        private readonly IBankAccountRepository _repository;
        private readonly IClock _clock;

        public NewAccountCreator(IBankAccountRepository repository, IClock clock)
        {
            _repository = repository;
            _clock = clock;
        }

        public void Create(CreateNewAccountCommand command)
        {
            var accountId = new AccountId(command.AccountId);

            var createdOn = new EventDateTime(_clock.Now);

            var account = BankAccount.Factory.OpenNewAccount(accountId, createdOn);

            _repository.Save(account);
        }
    }
}