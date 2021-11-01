using System;

namespace EventSourcedBank.Application
{
    public sealed record UnfreezeAccountCommand(Guid AccountId);
}