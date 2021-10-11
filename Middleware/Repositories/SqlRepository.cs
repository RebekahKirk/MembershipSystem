using MembershipSystem.Middleware.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
