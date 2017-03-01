using System.Collections.Generic;
using EventSourcedBank.Data.Read;
using EventSourcedBank.Domain;

namespace EventSourcedBank.Data.Write
{
    public sealed class BankAccountRepository : IBankAccountRepository
    {
        private static readonly Dictionary<AccountId, EventStream<BankAccountEvent>> Store =
            new Dictionary<AccountId, EventStream<BankAccountEvent>>();

        public void Save(BankAccount bankAccount)
        {
            Store[bankAccount.Id] = bankAccount;

            //Simultaneously update the read store
            BankAccountStateReader.Store[bankAccount.Id.Value] = new BankAccountData(
                bankAccount.Id.Value,
                bankAccount.State.CurrentBalance.Value);
        }

        public BankAccount Retrieve(AccountId accountId)
        {
            var retrievedEvents = Store[accountId];

            return BankAccount.Factory.Restore(accountId, retrievedEvents);
        }
    }
}