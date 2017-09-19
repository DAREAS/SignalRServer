using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using SignalRServerService.Entities;

namespace SignalRServerService.Hubs
{
    public class EventStoreHub : Hub
    {
        public void AddMessage(string name, string message)
        {
            var mongoDb = new Connect("messageQueue");
            mongoDb.SetDataBase();
            var collection = mongoDb.DataBase.GetCollection<DataMessage>("dataMessage");
            //var filter = MongoDB.Driver.Builders<DataMessage>.Filter.Eq("dataMessage.Id", message);
            //var currentEntity = collection.Find(filter);

            //currentEntity.

            //Console.WriteLine("Hub AddMessage {0} {1}\n", name, message);
            Clients.All.addMessage(name, message);
        }

        public void AddElement(string elementKey, string elementName, string elementBody)
        {
            var mongoDb = new Connect("messageQueue");
            mongoDb.SetDataBase();
            var collection = mongoDb.DataBase.GetCollection<Element>("element");

            var newElement = JsonConvert.DeserializeObject<DataMessage>(elementBody);

        }

        public override Task OnConnected()
        {
            Console.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected(stopCalled));
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("Hub OnReconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected(false));
        }
    }
}
