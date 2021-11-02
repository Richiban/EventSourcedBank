using System;

namespace Richiban.EventSourcedBank.Application
{
    public class BankAccountStateQuery
    {
        public Guid AccountId { get; }

        public BankAccountStateQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}