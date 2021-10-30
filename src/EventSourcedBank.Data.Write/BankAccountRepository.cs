using System.Collections.Generic;
using EventSourcedBank.Data.Read;
using EventSourcedBank.Domain;
using EventStore.ClientAPI;
using System.Net;
using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EventSourcedBank.Data.Write
{
    public sealed class BankAccountRepository : IBankAccountRepository
    {
        private const string StreamName = "BankAccount";

        private readonly IDictionary<string, List<string>> _store = new Dictionary<string, List<string>>();

        public void Save(BankAccount bankAccount)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));

            connection.ConnectAsync().Wait();

            var serializedAccountId = bankAccount.Id.Value.ToString();
            var serializedEvents = bankAccount.Select(evt => SerializeEvent(evt));

            //connection
            //    .AppendToStreamAsync(StreamName, ExpectedVersion.Any, myEvent)
            //    .Wait();

            _store[serializedAccountId] = serializedEvents.ToList();

            //Simultaneously update the read store
            BankAccountStateReader.Store[bankAccount.Id.Value] = MapBankAccountData(bankAccount);
        }

        public BankAccount Retrieve(AccountId accountId)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));

            connection.ConnectAsync().Wait();

            var eventStream =
                connection.ReadStreamEventsForwardAsync(StreamName, 0, 100, false).Result;

            var events1 = eventStream.Events;
            

            var events =
                from e in _store[accountId.Value.ToString()]
                let accountEvent = DeserializeEvent("AccountCreated", e)
                where accountEvent.AppliesTo.Equals(accountId)
                select accountEvent;

            return BankAccount.Factory.Restore(accountId, events);
        }

        private EventData MapEventToData(BankAccountEvent evt)
        {
            var eventId = Guid.NewGuid();
            var eventName = evt.GetType().Name;
            var isJson = true;
            var metadataBytes = new byte[] { };
            var dataBytes = Encoding.UTF8.GetBytes(SerializeEvent(evt));

            return new EventData(eventId, eventName, isJson, dataBytes, metadataBytes);
        }

        private string SerializeEvent(BankAccountEvent evt)
        {
            var jsonString = JsonConvert.SerializeObject(evt);

            return jsonString;
        }

        private static BankAccountEvent DeserializeEvent(string eventType, string dataString)
        {
            dynamic obj = JsonConvert.DeserializeObject(dataString)!;

            switch (eventType)
            {
                case nameof(AccountCreated):
                    var a = JsonConvert.DeserializeObject<AccountCreated>(dataString);

                    var b = new AccountCreated(
                        new AccountId((Guid)obj.AppliesTo.Value),
                        new EventId((int)obj.Id.Value),
                        new EventDateTime((DateTimeOffset)obj.OccurredOn.Value)
                        );

                    return b;
                default: throw new Exception($"Unrecognized event type: {eventType}");
            }
        }

        private static BankAccountEvent MapEventToDomain(RecordedEvent returnedEvent)
        {
            var eventType = returnedEvent.EventType;
            var dataString = Encoding.UTF8.GetString(returnedEvent.Data);

            return DeserializeEvent(eventType, dataString);
        }

        private static BankAccountData MapBankAccountData(BankAccount bankAccount)
            =>
            new BankAccountData(
                bankAccount.Id.Value,
                bankAccount.State.AccountOpenedOn.Value,
                bankAccount.State.CurrentBalance.Value,
                bankAccount.State.IsFrozen);
    }
}