using System;

namespace EventSourcedBank.Domain
{
    public struct EventDateTime
    {
        public EventDateTime(DateTimeOffset value)
        {
            Value = value;
        }

        public DateTimeOffset Value { get; }
    }
}