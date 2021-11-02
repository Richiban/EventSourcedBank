using System;

namespace Richiban.EventSourcedBank.Application
{
    public sealed class AccountIsFrozenException : Exception
    {
        public AccountIsFrozenException() : base("Account is frozen") { }
    }
}