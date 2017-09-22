using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SignalRServerService.Entities
{
    public class Element
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string BodyElement { get; set; }
        public long NumeroAcesso { get; set; }

        public List<DataMessage> DataMessage { get; set; }
    }
}
