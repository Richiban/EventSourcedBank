using System;

namespace EventSourcedBank.Data.Read
{
    public sealed class BankAccountData
    {
        public BankAccountData(Guid id, int balance)
        {
            Id = id;
            Balance = balance;
        }

        public Guid Id { get; }
        public int Balance { get; }
    }
}