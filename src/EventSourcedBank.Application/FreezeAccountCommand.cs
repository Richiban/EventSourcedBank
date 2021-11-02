using System;

namespace Richiban.EventSourcedBank.Application
{
    public sealed class FreezeAccountCommand
    {
        public FreezeAccountCommand(Guid accountId)
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}