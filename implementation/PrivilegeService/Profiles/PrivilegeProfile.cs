using AutoMapper;
using PrivilegeService.Dto;
using PrivilegeService.Models;

namespace PrivilegeService.Profiles
{
    public class PrivilegeProfile : Profile
    {
        public PrivilegeProfile()
        {
            CreateMap<Privilege, PrivilegeReadDto>();
            CreateMap<PrivilegeReadDto, Privilege>();
            CreateMap<PrivilegeReadDto, PrivilegePublish>();
            CreateMap<PrivilegeCreateDto, Privilege>();
        }
    }
}