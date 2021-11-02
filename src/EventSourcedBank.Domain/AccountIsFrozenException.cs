using System;

namespace Richiban.EventSourcedBank.Domain
{
    public class AccountIsFrozenException : Exception
    {
        public AccountIsFrozenException() : base("Account is frozen") {}
    }
}