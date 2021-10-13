using MembershipSystem.Middleware.Commands;
using MembershipSystem.Middleware.Entities;
using MembershipSystem.Middleware.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem.Middleware.Services
{
    public class EmployeeRecordService : IEmployeeRecordService
    {
        private readonly ISqlRepository _sqlRepository;

        public EmployeeRecordService(ISqlRepository sqlRepository)
        {
            this._sqlRepository = sqlRepository;
        }
        public async Task RegisterEmployee(RegisterEmployeeCommand command)
        {
            await _sqlRepository.RegisterEmployeeAsync(command.EmployeeId, command.EmployeeName, command.EmployeeEmail, command.EmployeeMobileNumber, command.Pin, command.CardId, command.Balance, command.ModifiedBy);
        }

        public async Task<EmployeeRecord> DatabaseRecord(string cardId)
        {
            var record = await _sqlRepository.DatabaseLookupAsync(cardId);
            return record;
        }
    }
}
