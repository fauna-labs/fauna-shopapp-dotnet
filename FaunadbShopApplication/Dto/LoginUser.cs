using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Dto
{
    public class LoginUser
    {
        [Required]
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
