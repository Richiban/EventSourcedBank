using System;

namespace EventSourcedBank.Domain
{
    public abstract class DomainEvent
    {
        protected DomainEvent(int id, DateTimeOffset occuredOn)
        {
            Id = id;
            OccuredOn = occuredOn;
        }

        public int Id { get; }
        public DateTimeOffset OccuredOn { get; }
    }
}