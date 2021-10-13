using AutoMapper;
using MembershipSystem.Middleware.Commands;
using MembershipSystem.Middleware.Entities;
using MembershipSystem.Middleware.Requests;
using MembershipSystem.Middleware.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Middleware.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterEmployeeRequest, RegisterEmployeeCommand>();
            CreateMap<EmployeeRecord, EmployeeRecordResponse>();
            CreateMap<TopUpCardRequest, TopUpCardCommand>();
        }
    }
}
