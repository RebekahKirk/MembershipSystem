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
            await _sqlRepository.RegisterEmployeeAsync(command.EmployeeId, command.EmployeeName, command.EmployeeEmail, command.EmployeeMobileNumber, command.Pin, command.CardId, command.Balance);
        }

        public async Task<EmployeeRecord> DatabaseRecord(string cardId)
        {
            var record = await _sqlRepository.DatabaseLookupAsync(cardId);
            return record;
        }

        public async Task<string> TopUpCard(TopUpCardCommand command)
        {
            var currentBalance = await _sqlRepository.GetBalanceAsync(command.CardId);
            var newBalance = Int32.Parse(currentBalance) + Int32.Parse(command.Amount);
            await _sqlRepository.TopUpCardAsync(command.CardId, newBalance.ToString());
            return newBalance.ToString();
        }

        public async Task<string> SpendOnCard(SpendOnCardCommand command)
        {
            var currentBalance = await _sqlRepository.GetBalanceAsync(command.CardId);

            if (Int32.Parse(command.Amount) > Int32.Parse(currentBalance))
            {
                throw new Exception("Your available balance is less than your required spend, please top up first.");
            }
            else
            {
                var newBalance = Int32.Parse(currentBalance) - Int32.Parse(command.Amount);
                await _sqlRepository.SpendOnCardAsync(command.CardId, newBalance.ToString());
                return newBalance.ToString();
            }
        }
    }
}
