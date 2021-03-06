using MembershipSystem.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem.Middleware.Interfaces
{
    public interface ISqlRepository
    {
        Task RegisterEmployeeAsync(string employeeId, string employeeName, string employeeEmail, string employeeMobileNumber, string pin, string cardId, int balance);
        Task<EmployeeRecord> DatabaseLookupAsync(string cardId);
        Task TopUpCardAsync(string pin, string cardId, string balance);
        Task<string> GetBalanceAsync(string cardId);
        Task SpendOnCardAsync(string pin, string cardId, string balance);
    }
}
