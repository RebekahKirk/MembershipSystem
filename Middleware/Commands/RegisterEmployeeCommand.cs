using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Middleware.Commands
{
    public class RegisterEmployeeCommand : BaseCommand
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public int EmployeeMobileNumber { get; set; }
        public int Pin { get; set; }
        public string CardId { get; set; }
        public int Balance { get; set; }
        public string ModifiedBy { get; set; }
    }
}
