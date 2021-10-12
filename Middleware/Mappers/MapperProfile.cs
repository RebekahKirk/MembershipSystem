using AutoMapper;
using MembershipSystem.Middleware.Commands;
using MembershipSystem.Middleware.Requests;
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
        }
    }
}
