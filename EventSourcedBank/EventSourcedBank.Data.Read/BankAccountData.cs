using System;

namespace EventSourcedBank.Data.Read
{
    public sealed class BankAccountData
    {
        public BankAccountData(Guid id, DateTimeOffset createdOn, int balance)
        {
            Id = id;
            CreatedOn = createdOn;
            Balance = balance;
        }

        public Guid Id { get; }
        public DateTimeOffset CreatedOn { get; }
        public int Balance { get; }
    }
}