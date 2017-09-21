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
        public string Message { get; set; }
        public string MessageBody { get; set; }
    }
}
