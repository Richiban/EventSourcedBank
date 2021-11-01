using System;

namespace EventSourcedBank.Data.Read
{
    public sealed record BankAccountData(
        Guid Id,
        DateTimeOffset CreatedOn,
        int Balance,
        bool IsFrozen);
}