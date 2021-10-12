using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem.Middleware.Interfaces
{
    public interface ISqlRepository
    {
        Task RegisterEmployeeAsync(string employeeId, string employeeName, string employeeEmail, int employeeMobileNumber, int pin, string cardId, int balance, string modifiedBy);
    }
}
