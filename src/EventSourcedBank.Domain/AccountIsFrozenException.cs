using System;

namespace EventSourcedBank.Domain
{
    public class AccountIsFrozenException : Exception
    {
        public AccountIsFrozenException() : base("Account is frozen") {}
    }
}