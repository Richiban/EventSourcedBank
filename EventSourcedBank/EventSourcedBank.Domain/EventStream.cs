using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EventSourcedBank.Domain
{
    public abstract class EventStream<T> : IReadOnlyCollection<T> where T : DomainEvent
    {
        protected readonly ImmutableList<T> Events;

        protected EventStream() : this(Enumerable.Empty<T>()) { }

        protected EventStream(IEnumerable<T> events)
        {
            Events = events.ToImmutableList();
        }

        public IEnumerator<T> GetEnumerator() => Events.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Events.Count;
    }
}
