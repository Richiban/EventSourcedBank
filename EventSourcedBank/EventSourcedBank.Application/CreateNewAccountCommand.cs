using System;

namespace EventSourcedBank.Application
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