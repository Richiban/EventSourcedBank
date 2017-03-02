namespace EventSourcedBank.Domain
{
    public abstract class DomainEvent
    {
        protected DomainEvent(EventId id, EventDateTime occuredOn)
        {
            Id = id;
            OccuredOn = occuredOn;
        }

        public EventId Id { get; }
        public EventDateTime OccuredOn { get; }
    }
}