using FaunaDB.Client;
using Microsoft.Extensions.Configuration;
using System;

namespace FaunadbShopApplication.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IConfiguration Configuration;

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected  FaunaClient GetClient()
        {
            var adminKey = Environment.GetEnvironmentVariable("ADMIN_KEY");
            var endPoint = Configuration["FaunaSettings:HOST"];
            return FaunaDbClient.GetClient(adminKey, endPoint);
        }
    }
}
