using System;
using System.Collections.Generic;

namespace EventSourcedBank.Data.Read
{
    public sealed class BankAccountStateRepository : IBankAccountStateRepository
    {
        internal static readonly Dictionary<Guid, BankAccountData> Store =
            new Dictionary<Guid, BankAccountData>();

        public BankAccountData Retrieve(Guid accountId) => Store[accountId];
    }
}