using ApplicationCore.Entities;
using ApplicationCore.Entities.MongoEntity;
using ApplicationCore.Interfaces.MongoDbRepository;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.MongoDb
{
    public class MongoDbRepository : IMongoDbRepository
    {
        private IMongoCollection<Buildings> _BuildingList;
        public MongoDbRepository(IMongoDbContext dbContext)
        {
            _BuildingList = dbContext.db.GetCollection<Buildings>("BuildingList");
        }

        public async Task Add(Buildings entity)
        {
            await _BuildingList.InsertOneAsync(entity);
        }

        public async Task<List<Buildings>> GetAll() =>
            (await _BuildingList.FindAsync(entity => true)).ToList();


        public async Task<Buildings> GetById(string Id) =>
            (await _BuildingList.FindAsync(x => x.Id == Id)).FirstOrDefault();

        public async Task<Buildings> GetByUserId(Guid userId) =>
            (await _BuildingList.FindAsync(x => x.UserId == userId)).FirstOrDefault();

        public async Task Remove(Buildings entity) =>
            await _BuildingList.DeleteOneAsync(x => x.Id.Equals(entity.Id));


        public async Task Remove(string Id) =>
            await _BuildingList.DeleteOneAsync(x => x.Id.Equals(Id));

        public async Task Update(string Id, Buildings entity) =>
            await _BuildingList.ReplaceOneAsync(x => x.Id == Id, entity);

        public async Task Update(Guid UserId, Buildings entity) =>
           await _BuildingList.ReplaceOneAsync(x => x.UserId == UserId, entity);
    }
}
