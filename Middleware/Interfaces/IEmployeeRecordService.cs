using MembershipSystem.Middleware.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem.Middleware.Interfaces
{
    public interface IEmployeeRecordService
    {
        Task RegisterEmployee(RegisterEmployeeCommand command);
    }
}
