using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using MongoDB.Bson;
using MongoDB.Driver;
using SignalRServerService.Entities;

namespace SignalRServerService.Hubs
{
    public class EventStoreHub : Hub
    {
        public void AddMessage(string elementKey, string elementName, string message, string messageBody)
        {
            try
            {
                var mongoDb = new Connect("messageQueue");
                mongoDb.SetDataBase();
                var collection = mongoDb.DataBase.GetCollection<Element>("elementMenssage");
                var filter = Builders<Element>.Filter.Eq("Id", elementKey);
                var update = Builders<Element>.Update.Push(element => element.DataMessage, new DataMessage{Message = message, MessageBody = messageBody});

                collection.UpdateOne(filter, update);

                Clients.Client(Context.ConnectionId).send($"Message add in => Element: {elementKey} - Message {messageBody}.");
            }
            catch (Exception exception)
            {
                Clients.Client(Context.ConnectionId).send($"Error on Message add. Exception: {exception}");

                throw;
            }
        }

        public void AddElement(string elementKey, string elementName, string elementBody)
        {
            try
            {
                var mongoDb = new Connect("messageQueue");
                mongoDb.SetDataBase();
                var collection = mongoDb.DataBase.GetCollection<Element>("element");

                var newElement = new Element
                {
                    Id = new ObjectId(),
                    Name = elementName,
                    BodyElement = elementBody,
                    DataMessage = new List<DataMessage>()
                };

                collection.InsertOne(newElement);

                Clients.Client(Context.ConnectionId).addElement(elementKey, elementName, "Body");
            }
            catch (Exception exception)
            {
                Clients.Client(Context.ConnectionId).addMessage(exception);
                throw;
            }
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
