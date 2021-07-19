using FaunadbShopApplication.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaunaDB.Client;
using FaunaDB.Types;
using static FaunaDB.Query.Language;

namespace FaunadbShopApplication.Repository
{
    public class ProductRepository :BaseRepository, IProductRepository
    {
        private const string CATEGORY_COLLECTION_NAME = "Categories";
        private const string CATEGORY_INDEX = "all_categories";

        private const string PRODUCT_COLLECTION_NAME = "Products";
        private const string RECENT_PRODUCTS_INDEX = "all_recent_products";
        private const int MAX_RECENT_PRODUCTS = 5;

        private const string PRODUCTS_SORTED_BY_NAME_PRICEIN_INDEX = "products_sorted_by_name_price";
        private const string PRODUCTS_BY_CATEGORY = "products_by_category";

        public ProductRepository(IConfiguration configuration):base(configuration)
        {
        }

        public async Task<bool> AddCategory(string name)
        {
            var client = GetClient();

            await client.Query(Create(
                               Collection(CATEGORY_COLLECTION_NAME),
                               Obj("data", Encoder.Encode(new Category() { Name = name}))
                           ));
            return true;
        }

        public async Task<bool> AddProduct(ProductDto product)
        {
            var client = GetClient();

            var faunaProd = new FaunaProduct(product, client);

            await client.Query(Create(
                               Collection(PRODUCT_COLLECTION_NAME),
                               Obj("data", Encoder.Encode(faunaProd))
                           ));
            return true;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();
            var client = GetClient();
            var values = await client.Query(Map(
                        Paginate(
                                    Match(Index(CATEGORY_INDEX))
                                ),
                                Lambda("categoryRef", Get(Var("categoryRef")))
                    )
                );
            IResult<Value[]> data = values.At("data").To<Value[]>();
            data.Match(
                Success: values =>
                     Array.ForEach(
                          values,  value => 
                                categories.Add(
                                                                 new Category()
                                                                 {
                                                                     Name = (value.At("data").At("name") as StringV).Value,
                                                                     Id = (value.At("ref") as RefV).Id
                                                                 }
                                                                            )
                                         )
                                   ,
                Failure: reason => Console.WriteLine($"Something went wrong: {reason}")
            );

            return categories;
        }

        public async Task<IEnumerable<Product>> GetRecentProducts()
        {
            var client = GetClient();
            var values = await client.Query(Map(Paginate(
                                                Match(Index(RECENT_PRODUCTS_INDEX)),
                                                size: MAX_RECENT_PRODUCTS
                                            ),
                                            Lambda(ArrayV.Of( "datetime", "prodRef"), Get(Var("prodRef")))
                                       ));
            
            IResult<Value[]> data = values.At("data").To<Value[]>();
            List<Product> products = await GetProducts(data.Value, client);

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsSortedByName()
        {
            var client = GetClient();
            var values = await client.Query(Map(Paginate(
                                                Match(Index(PRODUCTS_SORTED_BY_NAME_PRICEIN_INDEX))
                                            ),
                                            Lambda(ArrayV.Of("name","price", "prodRef"), Get(Var("prodRef")))
                                       ));

            IResult<Value[]> data = values.At("data").To<Value[]>();
            List<Product> products = await GetProducts(data.Value, client);

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryId)
        {
            var client = GetClient();
            var values = await client.Query(Map(Paginate(
                                                Match(Index(PRODUCTS_BY_CATEGORY), Ref(Collection(CATEGORY_COLLECTION_NAME), categoryId))
                                            ),
                                            Lambda("prodRef", Get(Var("prodRef")))
                                       ));

            IResult<Value[]> data = values.At("data").To<Value[]>();
            List<Product> products = await GetProducts(data.Value, client);

            return products;
        }

        private async Task<List<Product>> GetProducts(Value[] values, FaunaClient client)
        {
            List<Product> products = new List<Product>();
            foreach (Value value in values)
            {
                var product = Decoder.Decode<Product>(value.At("data"));
                product.Id = (value.At("ref") as RefV).Id;
                product.CategoryId = (value.At("data").At("category") as RefV).Id;
                var cat = await client.Query(Get(Ref(Collection(CATEGORY_COLLECTION_NAME), product.CategoryId)));
                product.CategoryName = cat.At("data").At("name").To<string>().Value;
                products.Add(product);
            }
            return products;
        }
    }
}
