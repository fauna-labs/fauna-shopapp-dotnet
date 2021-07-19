using System.Text.Json.Serialization;

namespace FaunadbShopApplication.Dto
{
    public class AuthentificatedUser: UserBase
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        public AuthentificatedUser() {}
        public AuthentificatedUser(User user) 
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            BirthDate = user.BirthDate;
            IdRef = user.IdRef;
        }
    }
}
