﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndependienteStaFe.Models
{
    public class registerUsuario
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
