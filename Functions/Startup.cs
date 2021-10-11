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
            builder.Services.AddLogging();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(this.GetType()));
        }
    }
}
