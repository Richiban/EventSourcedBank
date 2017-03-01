using System.Collections.Generic;
using EventSourcedBank.Data.Read;
using EventSourcedBank.Domain;

namespace EventSourcedBank.Data.Write
{
    public sealed class BankAccountRepository : IBankAccountRepository
    {
        private static readonly Dictionary<AccountId, BankAccount> Store =
            new Dictionary<AccountId, BankAccount>();

        public void Save(BankAccount bankAccount)
        {
            Store[bankAccount.Id] = bankAccount;
            BankAccountStateRepository.Store[bankAccount.Id.Value] = new BankAccountData(
                bankAccount.Id.Value,
                bankAccount.State.CurrentBalance.DecimalValue);
        }

        public BankAccount Retrieve(AccountId accountId) => Store[accountId];
    }
}