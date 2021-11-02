using System;

namespace Richiban.EventSourcedBank.Application
{
    public class CreateNewAccountCommand
    {
        public CreateNewAccountCommand(Guid accountId)
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}