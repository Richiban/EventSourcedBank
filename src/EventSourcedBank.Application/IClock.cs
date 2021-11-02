using System;

namespace Richiban.EventSourcedBank.Application
{
    public interface IClock
    {
        DateTimeOffset Now { get; }
    }
}