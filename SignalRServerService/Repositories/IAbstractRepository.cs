using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SignalRServerService.Repositories
{
    public interface IAbstractRepository<TModel>
    {
        IMongoCollection<TModel> GetCollection(string nameOfCollection);
        Task InsertAsync(TModel entity);
        void Insert(TModel entity);
        Task InsertManyAsync(List<TModel> entityList);
        void InsertMany(List<TModel> entityList);
        void Update(TModel entity, object updateValue, FilterDefinition<TModel> filter);
        void UpdateMany(TModel entity, object updateValue);
        void Delete(FilterDefinition<TModel> filter);
    }
}
