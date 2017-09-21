using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SignalRServerService.Entities;

namespace SignalRServerService.Repositories
{
    public class ElementRepository : IAbstractRepository<Element>
    {
        public IMongoCollection<Element> GetCollection(string nameOfCollection)
        {
            return new MongoClient().GetDatabase("messageQueue").GetCollection<Element>(nameOfCollection);
        }

        public Task InsertAsync(Element entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Element entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(List<Element> entityList)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(List<Element> entityList)
        {
            throw new NotImplementedException();
        }

        public void Update(Element entity, object updateValue, FilterDefinition<Element> filter)
        {
            throw new NotImplementedException();
        }

        public void UpdateMany(Element entity, object updateValue)
        {
            throw new NotImplementedException();
        }

        public void Delete(FilterDefinition<Element> filter)
        {
            throw new NotImplementedException();
        }
    }
}
