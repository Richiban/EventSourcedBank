using System;

namespace EventSourcedBank.Application
{
    public sealed class Clock : IClock
    {
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
    }
}