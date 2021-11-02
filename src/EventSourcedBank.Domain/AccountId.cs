using System;

namespace Richiban.EventSourcedBank.Domain
{
    public record AccountId(Guid Value)
    {
        public static AccountId NewId() => new(Guid.NewGuid());
    }
}