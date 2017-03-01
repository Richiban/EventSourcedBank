using System;

namespace EventSourcedBank.Data.Read
{
    public sealed class BankAccountData
    {
        public BankAccountData(Guid id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }

        public Guid Id { get; }
        public decimal Balance { get; }
    }
}