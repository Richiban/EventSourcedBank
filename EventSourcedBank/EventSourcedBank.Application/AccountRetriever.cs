using EventSourcedBank.Data.Read;

namespace EventSourcedBank.Application
{
    public sealed class AccountRetriever
    {
        public BankAccountData Retrieve(BankAccountStateQuery bankAccountStateQuery)
            => new BankAccountStateRepository().Retrieve(bankAccountStateQuery.AccountId);
    }
}