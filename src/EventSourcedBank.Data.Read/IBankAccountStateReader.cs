using System;

namespace EventSourcedBank.Data.Read
{
    public interface IBankAccountStateReader
    {
        BankAccountData Retrieve(Guid accountId);
    }
}