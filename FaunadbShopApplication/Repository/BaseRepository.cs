using FaunaDB.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var adminKey = Configuration["FaunaSettings:ADMIN_KEY"];
            var endPoint = Configuration["FaunaSettings:HOST"];
            return FaunaDbClient.GetClient(adminKey, endPoint);
        }
    }
}
