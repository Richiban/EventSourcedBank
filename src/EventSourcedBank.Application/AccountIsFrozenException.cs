using System;

namespace EventSourcedBank.Application
{
    public sealed class AccountIsFrozenException : Exception
    {
        public AccountIsFrozenException() : base("Account is frozen") { }
    }
}