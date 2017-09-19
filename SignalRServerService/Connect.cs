using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SignalRServerService
{
    public class Connect
    {
        private readonly string _connectionString;
        private readonly MongoClient _client;
        private readonly string _dataBaseName;

        public IMongoDatabase DataBase;

        public Connect(string databaseName)
        {
            _dataBaseName = databaseName;
            //_connectionString = "localhost:27017";
            _client = new MongoClient();
        }

        public void SetDataBase()
        {
            DataBase = _client.GetDatabase(_dataBaseName);
        }

    }
}
