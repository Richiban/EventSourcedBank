using System.Collections.Generic;

namespace EventSourcedBank.Domain
{
    public sealed class BankAccountState
    {
        public BankAccountState(Money currentBalance)
        {
            CurrentBalance = currentBalance;
        }

        public Money CurrentBalance { get; }
    }
}