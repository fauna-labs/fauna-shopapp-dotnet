using FaunaDB.Types;
using FaunadbShopApplication.Repository;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FaunadbShopApplication.Dto
{
    public class User: UserBase
    {
        [Required]
        [FaunaField("password")]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
