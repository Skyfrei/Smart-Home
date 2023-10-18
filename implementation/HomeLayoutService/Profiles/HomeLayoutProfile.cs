using AutoMapper;
using HomeLayoutService.Dto;
using HomeLayoutService.Models;

namespace HomeLayoutService.Profiles
{
    public class HomeLayoutProfile : Profile
    {
        public HomeLayoutProfile()
        {
            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomCreateDto, RoomPublishedDto>();
            CreateMap<RoomReadDto, RoomPublishedDto>();
            CreateMap<DeviceCreateDto, Device>();
        }
    }
}