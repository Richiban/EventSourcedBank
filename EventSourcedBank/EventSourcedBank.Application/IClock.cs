using System;

namespace EventSourcedBank.Application
{
    public interface IClock
    {
        DateTimeOffset Now { get; }
    }
}