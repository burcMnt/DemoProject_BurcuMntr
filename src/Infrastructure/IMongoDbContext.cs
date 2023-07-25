using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IMongoDbContext
    {
        IMongoDatabase db { get; }
        void initial();
    }
}
