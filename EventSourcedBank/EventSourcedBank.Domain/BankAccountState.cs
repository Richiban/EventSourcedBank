namespace EventSourcedBank.Domain
{
    public sealed class BankAccountState
    {
        public BankAccountState(Money currentBalance, EventDateTime eventOn)
        {
            CurrentBalance = currentBalance;
            EventOn = eventOn;
        }

        public Money CurrentBalance { get; }
        public EventDateTime EventOn { get; }

        public BankAccountState WithBalance(Money newBalance) => new BankAccountState(newBalance, EventOn);
    }
}