using MembershipSystem.Middleware.Entities;
using MembershipSystem.Middleware.Interfaces;
using MembershipSystem.Middleware.Repositories;
using MembershipSystem.Middleware.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

[assembly: FunctionsStartup(typeof(MembershipSystem.Functions.Startup))]

namespace MembershipSystem.Functions
{
    public class Startup : FunctionsStartup 
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new Config
            {
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString")
            };

            builder.Services.AddLogging();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(this.GetType()));
            builder.Services.AddSingleton<IEmployeeRecordService, EmployeeRecordService>();
            builder.Services.AddSingleton<ISqlRepository, SqlRepository>(s => new SqlRepository(config.ConnectionString.ToString()));
        }
    }
}
