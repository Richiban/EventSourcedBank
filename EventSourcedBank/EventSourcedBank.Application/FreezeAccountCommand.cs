using System;

namespace EventSourcedBank.Application
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