using System;

namespace Richiban.EventSourcedBank.Domain
{
    public record EventDateTime(DateTimeOffset Value)
    {
        public static EventDateTime MinValue => new(DateTimeOffset.MinValue);
    }
}