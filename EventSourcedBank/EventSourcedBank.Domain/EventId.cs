using System;

namespace EventSourcedBank.Domain
{
    public struct EventId
    {
        public EventId(int value)
        {
            Value = value;
        }

        public int Value { get; }

        internal static EventId NewId()
        {
            return new EventId(0);
        }
    }
}