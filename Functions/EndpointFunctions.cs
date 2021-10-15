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
using MembershipSystem.Middleware.Responses;
using System.Collections.Generic;
using System.Linq;
using MembershipSystem.Middleware.Entities;
using System.Net.Http;
using MembershipSystem.Utilities;

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
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "employeerecord")][FromBody] RegisterEmployeeRequest request)
        {
            var payloadParser = new PayloadParser();

            if (!payloadParser.CheckRegistrationPayload(request))
            {
                HttpResponseMessage msg = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ReasonPhrase = "Missing data – error "
                };
                return new BadRequestObjectResult(msg.ReasonPhrase);
            }

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
            return new OkObjectResult($"Registration sucessful, welcome {command.EmployeeName}.");
        }


        [FunctionName("DatabaseLookup")]
        public async Task<IActionResult> DatabaseLookup(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "employeerecord/{cardId}")] HttpRequest req, string cardId)
        {

            _logger.LogInformation("C# HTTP trigger get employee by card id");

            var record = await _employeeRecordService.DatabaseRecord(cardId);
            if (record == null)
                return new NotFoundObjectResult("Existing record not found in database, please register card.");

            var response = _mapper.Map<EmployeeRecordResponse>(record);

            return new OkObjectResult($"Hello, {response.EmployeeName}");
        }

        [FunctionName("TopUpCard")]
        public async Task<IActionResult> TopUpCard(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "topupcard")][FromBody] TopUpCardRequest request)
        {

            var command = _mapper.Map<TopUpCardCommand>(request);
            command.Username = "System";
            _logger.LogInformation("C# HTTP Trigger PUT - top up card");

            try
            {
                var balance = await _employeeRecordService.TopUpCard(command);
                return new OkObjectResult($"Top Up Sucessful - Your new balance is {balance}");
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("SpendOnCard")]
        public async Task<IActionResult> SpendOnCard(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "spendoncard")][FromBody] SpendOnCardRequest request)
        {
            var command = _mapper.Map<SpendOnCardCommand>(request);
            command.Username = "System";
            _logger.LogInformation("C# HTTP Trigger PUT - top up card");

            try
            {
                await _employeeRecordService.SpendOnCard(command);
                return new OkObjectResult($"Payment complete, thank you.");
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
