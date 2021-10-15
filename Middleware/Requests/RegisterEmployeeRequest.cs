using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Middleware.Requests
{
    public class RegisterEmployeeRequest
    {
        [JsonProperty("employeeid")]
        public string EmployeeId { get; set; }

        [JsonProperty("employeename")]
        public string EmployeeName { get; set; }

        [JsonProperty("employeeemail")]
        public string EmployeeEmail { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("cardid")]
        public string CardId { get; set; }

        [JsonProperty("balance")]
        public int Balance { get; set; }
        [JsonProperty("employeemobilenumber")]
        public string EmployeeMobileNumber { get; set; }
    }
}

