using System.Collections.Generic;

namespace EventSourcedBank.Domain
{
    public sealed class AccountOwner : EventStream<OwnerEvent>
    {
        private AccountOwner AppendEvent(OwnerEvent evt) => new AccountOwner(Events.Add(evt));

        public AccountOwner() : base() { }
        public AccountOwner(IEnumerable<OwnerEvent> events) : base(events) { }

        public AccountOwner ChangeName(Name name) => AppendEvent(new NameChanged(name));
    }
}