using FaunaDB.Client;

namespace FaunadbShopApplication.Repository
{
    
    public static  class FaunaDbClient
    {
        private const string ENDPOINT = "https://db.fauna.com:443";
        public static FaunaClient GetClient(string secret, string endpoint = ENDPOINT) =>
            new FaunaClient(endpoint: endpoint, secret: secret);
    }
}
