namespace EventSourcedBank.Domain
{
    public sealed class BankAccountState
    {
        public BankAccountState(Money currentBalance, EventDateTime accountOpenedOn, bool isFrozen)
        {
            CurrentBalance = currentBalance;
            AccountOpenedOn = accountOpenedOn;
            IsFrozen = isFrozen;
        }

        public Money CurrentBalance { get; }
        public EventDateTime AccountOpenedOn { get; }
        public bool IsFrozen { get; }

        public BankAccountState WithBalance(Money newBalance)
            => new BankAccountState(newBalance, AccountOpenedOn, IsFrozen);

        public BankAccountState WithFrozen(bool isFrozen)
            => new BankAccountState(CurrentBalance, AccountOpenedOn, isFrozen);
    }
}