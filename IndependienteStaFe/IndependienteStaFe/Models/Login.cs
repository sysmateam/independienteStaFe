using Newtonsoft.Json;

namespace IndependienteStaFe.Models
{
    public class Login
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("Jwt")]
        public string Jwt { get; set; }


    }
}
