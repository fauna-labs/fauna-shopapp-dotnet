using FaunaDB.Client;
using FaunaDB.Types;
using static FaunaDB.Query.Language;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FaunadbShopApplication.Dto
{
    public class FaunaProduct
    {
        [FaunaField("name")]
        public string Name { get; set; }

        [FaunaField("price")]
        public double Price { get; set; }

        [FaunaField("weight")]
        public double Weight { get; set; }

        [FaunaField("datetime")]
        public DateTime CreatedAt { get; set; }

        [FaunaField("category")]
        public RefV InCategoryId { get; set; }

        [FaunaField("quantity")]
        public double Quantity { get; set; }


        public FaunaProduct(ProductDto product, FaunaClient client)
        {
            Name = product.Name;
            Price = product.Price;
            Weight = product.Weight;
            CreatedAt = DateTime.UtcNow;
            Quantity = product.Quantity;
            if (!FillCategoryReference(product.CategoryId, client).ConfigureAwait(false).GetAwaiter().GetResult())
            {
                throw new ArgumentException("Can't find category");
            }
        }

        private async Task<bool> FillCategoryReference(string category, FaunaClient client)
        {
            var categoryReference = await client.Query(Get(Ref(
                Collection("Categories"), category
            )));
            InCategoryId = categoryReference.At("ref") as RefV;
            return true;
        }
    }
}
