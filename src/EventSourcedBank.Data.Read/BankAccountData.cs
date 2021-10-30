using System;

namespace EventSourcedBank.Data.Read
{
    public sealed class BankAccountData
    {
        public BankAccountData(Guid id, DateTimeOffset createdOn, int balance, bool isFrozen)
        {
            Id = id;
            CreatedOn = createdOn;
            Balance = balance;
            IsFrozen = isFrozen;
        }

        public Guid Id { get; }
        public DateTimeOffset CreatedOn { get; }
        public int Balance { get; }
        public bool IsFrozen { get; }
    }
}