using System;
using Richiban.EventSourcedBank.Data.Read;

namespace Richiban.EventSourcedBank.Application
{
    public sealed class AccountRetriever
    {
        public BankAccountData Retrieve(BankAccountStateQuery bankAccountStateQuery)
            => new BankAccountStateReader().Retrieve(bankAccountStateQuery.AccountId);
    }
}