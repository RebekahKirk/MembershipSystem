using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Middleware.Requests
{
    public class SpendOnCardRequest
    {
        [JsonProperty("pin")]
        public string Pin { get; set; }
        [JsonProperty("cardid")]
        public string CardId { get; set; }
        [JsonProperty("balance")]
        public string Balance { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}
