using System;

namespace Richiban.EventSourcedBank.Application
{
    public sealed class MakeWithdrawalCommand
    {
        public MakeWithdrawalCommand(Guid accountId, int amountInPence)
        {
            AccountId = accountId;
            AmountInPence = amountInPence;
        }

        public Guid AccountId { get; }
        public int AmountInPence { get; }
    }
}