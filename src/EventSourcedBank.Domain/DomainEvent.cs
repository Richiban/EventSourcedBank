namespace EventSourcedBank.Domain
{
    public abstract record DomainEvent(EventId Id, EventDateTime OccurredOn);
}