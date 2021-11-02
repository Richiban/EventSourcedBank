using System;

namespace Richiban.EventSourcedBank.Application
{
    public sealed record UnfreezeAccountCommand(Guid AccountId);
}