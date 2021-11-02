using System;

namespace Richiban.EventSourcedBank.Data.Read
{
    public interface IBankAccountStateReader
    {
        BankAccountData Retrieve(Guid accountId);
    }
}