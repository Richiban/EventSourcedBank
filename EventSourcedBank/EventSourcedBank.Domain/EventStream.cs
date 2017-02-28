using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EventSourcedBank.Domain
{
    public abstract class EventStream<T> : IEnumerable<T> where T : DomainEvent
    {
        protected readonly ImmutableList<T> Events;

        public EventStream() : this(Enumerable.Empty<T>()) { }

        public EventStream(IEnumerable<T> events)
        {
            Events = events.ToImmutableList();
        }

        public IEnumerator<T> GetEnumerator() => Events.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
