using System;

namespace EventSourcedBank.Domain
{
    public sealed class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base(ErrorMessage)
        {
        }

        private const string ErrorMessage =
            "There are insufficient funds to complete the requested operation";
    }
}