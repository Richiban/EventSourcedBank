namespace EventSourcedBank.Domain
{
    public struct Name
    {
        public Name(string value) { Value = value; }

        public string Value { get; }
    }
}