using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AutoMapper;

namespace MembershipSystem.Functions
{
    public class EndpointFunctions
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EndpointFunctions> _logger;

        public EndpointFunctions(IMapper mapper, ILogger<EndpointFunctions> logger)
        {
            this._logger = logger;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[FunctionName("Function1")]
    }
}
