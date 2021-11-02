﻿using System;
using Richiban.EventSourcedBank.Domain;

namespace Richiban.EventSourcedBank.Data.Write
{
    public interface IBankAccountRepository
    {
        void Save(BankAccount bankAccount);
        BankAccount Retrieve(AccountId accountId);
    }
}