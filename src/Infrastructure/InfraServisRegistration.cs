using ApplicationCore.Interfaces.MongoDbRepository;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Repositories.MongoDb;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfraServisRegistration
    {
        public static void AddInfraServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            serviceCollection.AddScoped<IMongoDbContext, MongoDbContext>();
            serviceCollection.AddScoped<IMongoDbRepository, MongoDbRepository>();
        }
    }
}
