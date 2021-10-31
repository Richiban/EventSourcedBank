namespace EventSourcedBank.Domain
{
    public sealed record BankAccountState(
        Money CurrentBalance,
        EventDateTime AccountOpenedOn,
        bool IsFrozen);
}