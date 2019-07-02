using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndependienteStaFe.Models
{
    public class Redencion
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("codeRedemption")]
        public string CodeRedemption { get; set; }
    }
}
