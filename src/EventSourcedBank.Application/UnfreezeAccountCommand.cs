using System;

namespace EventSourcedBank.Application
{
    public sealed class UnfreezeAccountCommand
    {
        public Guid AccountId { get; }

        public UnfreezeAccountCommand(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}