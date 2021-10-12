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
using MembershipSystem.Middleware.Commands;
using MembershipSystem.Middleware.Requests;
using MembershipSystem.Middleware.Interfaces;

namespace MembershipSystem.Functions
{
    public class EndpointFunctions
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EndpointFunctions> _logger;
        private readonly IEmployeeRecordService _employeeRecordService;

        public EndpointFunctions(IMapper mapper, ILogger<EndpointFunctions> logger, IEmployeeRecordService employeeRecordService)
        {
            this._logger = logger;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._employeeRecordService = employeeRecordService ?? throw new ArgumentNullException(nameof(employeeRecordService));
        }

        [FunctionName("RegisterEmployee")]
        public async Task<IActionResult> RegisterEmployee(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "employeerecord")] [FromBody] RegisterEmployeeRequest request)
        {
            var command = _mapper.Map<RegisterEmployeeCommand>(request);
            command.Username = "System";
            _logger.LogInformation("C# Trigger create new employee record in database");

            try
            {
                await _employeeRecordService.RegisterEmployee(command);
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkObjectResult(command.EmployeeId);
        }
    }
}