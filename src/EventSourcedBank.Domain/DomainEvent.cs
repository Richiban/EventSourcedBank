namespace EventSourcedBank.Domain
{
    public abstract class DomainEvent
    {
        protected DomainEvent(EventId id, EventDateTime occurredOn)
        {
            Id = id;
            OccurredOn = occurredOn;
        }

        public EventId Id { get; }
        public EventDateTime OccurredOn { get; }
    }
}