using System;

namespace Richiban.EventSourcedBank.Application
{
    public sealed class Clock : IClock
    {
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
    }
}