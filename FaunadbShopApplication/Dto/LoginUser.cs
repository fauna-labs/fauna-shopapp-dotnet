using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
