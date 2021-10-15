using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Middleware.Entities
{
    public class EmployeeRecord
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public string Pin { get; set; }
        public string CardId { get; set; }
        public int Balance { get; set; }

    }
}
