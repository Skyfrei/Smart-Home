using AutoMapper;
using HomeLayoutService.AsyncDataService;
using HomeLayoutService.Data;
using HomeLayoutService.Dto;
using HomeLayoutService.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeLayoutService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeLayoutController : ControllerBase
    {
        private readonly IHomeLayoutRepo _repo;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public HomeLayoutController(IHomeLayoutRepo repo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _repo = repo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        [ActionName("GetAllRooms")]
        public ActionResult<IEnumerable<RoomReadDto>> GetRooms()
        {
            Console.WriteLine("----------> Getting rooms....");

            var home = _repo.GetRooms();

            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(home));
        }

        [HttpGet]
        [ActionName("GetAllDevices")]
        public ActionResult<IEnumerable<Device>> GetAllDevice()
        {
            Console.WriteLine("----------> Getting rooms....");

            var home = _repo.GetAllDevices();

            return Ok(_mapper.Map<IEnumerable<Device>>(home));
        }

        [HttpPost]
        [ActionName("ChangeRoomSmartDevice")]
        public ActionResult<RoomCreateDto> ChangeRoomSmartDevice(RoomCreateDto roomDto)
        {
            Console.WriteLine("Changing room's smart device.");
            Console.WriteLine("-========================>"+roomDto.Id);
            Console.WriteLine(roomDto.SmartDeviceId);
            Console.WriteLine(roomDto.Name);
            _repo.ChangeRoomSmartDevice(roomDto.Id, roomDto.SmartDeviceId);
            _repo.SaveChanges();

            return Ok("Changed.");
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public ActionResult<RoomReadDto> GetRoomById(int id)
        {
            var notificationItem = _repo.GetRoomById(id);

            if (notificationItem != null)
            {
                return Ok(_mapper.Map<RoomReadDto>(notificationItem));
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("CreateNewRoom")]
        public ActionResult<RoomCreateDto> CreateNewRoom(RoomCreateDto roomCreateDto)
        {
            var roomCreated = _mapper.Map<Room>(roomCreateDto);

            _repo.CreateRoom(roomCreated);
            _repo.SaveChanges();
            
            var roomReadDto = _mapper.Map<RoomReadDto>(roomCreated);

            try
            {
                var publishedPrivilege = _mapper.Map<RoomPublishedDto>(roomReadDto);
                // _messageBus.PublishUSer(publishedPrivilege);
            }
            catch(Exception e)
            {
                Console.WriteLine($"asdiasdasidjasidjasidjasidjaisdiasj----->{e}");
            }
            
            return Ok("---> Created new user!");
        }

        [HttpPost]
        [ActionName("AddNewDevice")]
        public ActionResult<DeviceCreateDto> AddDevice(DeviceCreateDto deviceCreateDto)
        {
            var deviceCreated = _mapper.Map<Device>(deviceCreateDto);

            _repo.CreateNewDevcie(deviceCreated);
            _repo.SaveChanges();
            
            return Ok("---> Added new device!");
        }


        // [HttpPost]
        // public ActionResult<RoomReadDto> CreateNewRoom(RoomCreateDto roomCreateDto)
        // {
        //     var room = _mapper.Map<Room>(roomCreateDto);

        //     _repo.CreateRoom(room);
        //     _repo.SaveChanges();

        //     var roomReadDto = _mapper.Map<RoomReadDto>(room);

        //     return CreatedAtRoute(nameof(GetRoomById), new { Id = roomReadDto.Id}, roomReadDto);
        // }

    }
}