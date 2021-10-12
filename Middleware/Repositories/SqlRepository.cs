using Dapper;
using MembershipSystem.Helpers;
using MembershipSystem.Middleware.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public async Task RegisterEmployeeAsync(string employeeId, string employeeName, string employeeEmail, int employeeMobileNumber, int pin, string cardId, int balance, string modifiedBy)
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
                    modifiedBy,
                    Mode = SaveModeHelper.Create
                },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
