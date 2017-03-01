using System;

namespace EventSourcedBank.Data.Read
{
    public interface IBankAccountStateRepository
    {
        BankAccountData Retrieve(Guid accountId);
    }
}