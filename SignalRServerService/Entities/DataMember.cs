using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SignalRServerService.Entities
{
    public class DataMessage
    {
        public ObjectId Id { get; set; }
        public string Element { get; set; }
        public List<string> Message { get; set; }
    }
}
