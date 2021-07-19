using FaunaDB.Types;
using FaunadbShopApplication.Repository;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FaunadbShopApplication.Dto
{
    public class UserBase
    {
        [Required]
        [FaunaField("firstName")]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [FaunaField("lastName")]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [FaunaField("birthday")]
        [JsonPropertyName("birthday")]
        public DateTime BirthDate { get; set; }

        [Required]
        [FaunaField("phone")]
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        [FaunaField("address")]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [FaunaField("user_type")]
        [JsonPropertyName("user_type")]
        public UserRoles UserType;

        public string IdRef;
    }
}
