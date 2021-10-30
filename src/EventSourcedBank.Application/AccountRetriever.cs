using EventSourcedBank.Data.Read;

namespace EventSourcedBank.Application
{
    public sealed class AccountRetriever
    {
        public BankAccountData Retrieve(BankAccountStateQuery bankAccountStateQuery)
            => new BankAccountStateReader().Retrieve(bankAccountStateQuery.AccountId);
    }
}