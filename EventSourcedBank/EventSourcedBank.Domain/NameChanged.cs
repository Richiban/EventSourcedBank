namespace EventSourcedBank.Domain
{
    public sealed class NameChanged : OwnerEvent
    {
        public NameChanged(Name name) { NewName = name; }

        public Name NewName { get; }
    }
}