using System;

namespace EventSourcedBank.Domain
{
    public record AccountId(Guid Value)
    {
        public static AccountId NewId() => new(Guid.NewGuid());
    }
}