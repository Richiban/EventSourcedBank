namespace EventSourcedBank.Domain
{
    public sealed class BankAccountState
    {
        public BankAccountState(Money currentBalance, EventDateTime accountOpenedOn)
        {
            CurrentBalance = currentBalance;
            AccountOpenedOn = accountOpenedOn;
        }

        public Money CurrentBalance { get; }
        public EventDateTime AccountOpenedOn { get; }

        public BankAccountState WithBalance(Money newBalance) => new BankAccountState(newBalance, AccountOpenedOn);
    }
}