using MembershipSystem.Middleware.Commands;
using MembershipSystem.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem.Middleware.Interfaces
{
    public interface IEmployeeRecordService
    {
        Task RegisterEmployee(RegisterEmployeeCommand command);
        Task<EmployeeRecord> DatabaseRecord(string cardId);
        Task<string> TopUpCard(TopUpCardCommand command);
        Task<string> SpendOnCard(SpendOnCardCommand command);
    }
}
