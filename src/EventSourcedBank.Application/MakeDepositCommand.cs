using System;

namespace EventSourcedBank.Application
{
    public sealed class MakeDepositCommand
    {
        public Guid AccountId { get; }
        public int AmountInPence { get; }

        public MakeDepositCommand(Guid accountId, int amountInPence)
        {
            AccountId = accountId;
            AmountInPence = amountInPence;
        }
    }
}