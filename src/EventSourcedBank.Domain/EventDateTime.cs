using System;

namespace EventSourcedBank.Domain
{
    public record EventDateTime(DateTimeOffset Value)
    {
        public static EventDateTime MinValue => new(DateTimeOffset.MinValue);
    }
}