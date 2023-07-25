using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db;
        private static MongoClient _client;
        public IMongoDatabase db => _db;
        public MongoDbContext()
        {
            if (_db == null)
            {
                initial();
            }
        }

        public void initial()
        {
            if (_client == null)
            {
                _client = new MongoClient();
            }

            if (_client != null && _db == null)
            {
                _db = _client.GetDatabase("DemoProjectPanteon");
            }
        }
    }
}
