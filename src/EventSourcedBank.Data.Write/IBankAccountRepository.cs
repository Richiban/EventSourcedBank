using EventSourcedBank.Domain;

namespace EventSourcedBank.Data.Write
{
    public interface IBankAccountRepository
    {
        void Save(BankAccount bankAccount);
        BankAccount Retrieve(AccountId accountId);
    }
}