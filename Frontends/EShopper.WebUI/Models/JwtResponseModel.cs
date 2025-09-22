using System.Text.Json.Serialization;

namespace EShopper.WebUI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        [JsonPropertyName("expireTime")]
        public DateTime ExpireDate { get; set; }
    }
}
