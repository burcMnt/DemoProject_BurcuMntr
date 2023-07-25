using ApplicationCore.Entities.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.MongoDbRepository
{
    public interface IMongoDbRepository
    {
        Task<Buildings> GetById(string itemId);
        Task<Buildings> GetByUserId(Guid userId);
        Task<List<Buildings>> GetAll();
        Task Add(Buildings entity);
        Task Update(string itemId, Buildings entity);
        Task Remove(Buildings entity);
        Task Remove(string itemId);

    }
}
