using System;
using System.Collections.Generic;

namespace Richiban.EventSourcedBank.Data.Read
{
    public sealed class BankAccountStateReader : IBankAccountStateReader
    {
        public static readonly Dictionary<Guid, BankAccountData> Store =
            new();

        public BankAccountData Retrieve(Guid accountId) => Store[accountId];
    }
}