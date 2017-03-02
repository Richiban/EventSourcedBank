namespace EventSourcedBank.Domain
{
    public struct EventId
    {
        public EventId(int value)
        {
            Value = value;
        }

        private int Value { get; }
    }
}