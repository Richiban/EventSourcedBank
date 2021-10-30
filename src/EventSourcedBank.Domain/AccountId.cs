using System;

namespace EventSourcedBank.Domain
{
    public struct AccountId
    {
        public AccountId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static AccountId NewId() => new AccountId(Guid.NewGuid());
    }
}