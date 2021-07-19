using FaunaDB.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FaunadbShopApplication.Dto
{
    public class Product
    {
        [Required]
        [JsonPropertyName("name")]
        [FaunaField("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("price")]
        [FaunaField("price")]
        public double Price { get; set; }

        [Required]
        [JsonPropertyName("weight")]
        [FaunaField("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("datetime")]
        [FaunaField("datetime")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("categoryid")]
        public string CategoryId { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }
        
        [Required]
        [JsonPropertyName("quantity")]
        [FaunaField("quantity")]
        public double Quantity { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
