﻿namespace EventSourcedBank.Domain
{
    public record EventId(int Value)
    {
        internal static EventId NewId() => new(0);
    }
}