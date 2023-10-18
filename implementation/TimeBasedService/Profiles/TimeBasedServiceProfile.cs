using AutoMapper;
using TimeBasedService.DataTransferObject;
using TimeBasedService.Models;

namespace TimeBasedService.Profiles
{
    public class TimeBasedServiceProfile : Profile
    {
        public TimeBasedServiceProfile()
        {
            CreateMap<BaseService, TimeBasedServiceReadDto>();
            CreateMap<TimeBasedServiceReadDto, BaseService>();
            CreateMap<TimeBasedServiceReadDto, TimeBasedServicePublish>();
            CreateMap<TimeBasedServiceCreateDto, BaseService>();
        }
    }
}