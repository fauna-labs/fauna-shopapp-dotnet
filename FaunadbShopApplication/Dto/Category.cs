using FaunaDB.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FaunadbShopApplication.Dto
{
    public class Category
    {
        [Required]
        [FaunaField("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
