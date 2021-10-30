using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace EventSourcedBank.Domain
{
    public abstract class EventStream<T> : IReadOnlyCollection<T> where T : DomainEvent
    {
        protected readonly ImmutableList<T> Events;

        protected EventStream() : this(ImmutableList.Create<T>()) { }

        protected EventStream(ImmutableList<T> events)
        {
            Events = events;
        }

        public IEnumerator<T> GetEnumerator() => Events.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Events.Count;
    }
}
