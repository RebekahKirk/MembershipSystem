using Dapper;
using MembershipSystem.Helpers;
using MembershipSystem.Middleware.Entities;
using MembershipSystem.Middleware.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem.Middleware.Repositories
{
    public class SqlRepository : ISqlRepository
    {
        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public string GetConnectionName()
        {
            return _connectionString.ToString();
        }

        public async Task RegisterEmployeeAsync(string employeeId, string employeeName, string employeeEmail, int employeeMobileNumber, int pin, string cardId, int balance)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                await sqlConnection.ExecuteAsync($"[dbo].[uspEmployeeRecordCrud]", new
                {
                    employeeId,
                    employeeName,
                    employeeEmail,
                    employeeMobileNumber,
                    pin,
                    cardId,
                    balance,
                    Mode = SaveModeHelper.Create
                },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<EmployeeRecord> DatabaseLookupAsync(string cardId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var query = await sqlConnection.QueryAsync<EmployeeRecord>($"[dbo].[uspEmployeeRecordCrud]", new
                {
                    cardId = cardId,
                    Mode = SaveModeHelper.Get
                },
                    commandType: CommandType.StoredProcedure);
                return query.FirstOrDefault();
            }

        }
        public async Task TopUpCardAsync(/*int pin,*/ string cardId, string balance)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                await sqlConnection.ExecuteAsync($"[dbo].[uspEmployeeRecordCrud]", new
                {
                    //pin,
                    cardId,
                    balance,
                    Mode = SaveModeHelper.Update
                },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<string> GetBalanceAsync(string cardId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var balance = await sqlConnection.ExecuteScalarAsync($"[dbo].[uspEmployeeRecordCrud]", new
                {
                    cardId,
                    Mode = SaveModeHelper.Balance
                },
                    commandType: CommandType.StoredProcedure);

                return balance.ToString();
            }
        }
    }
}
    
