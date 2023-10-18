using System.Text.Json;
using ApiGateway.Data;
using ApiGateway.Dto;
using ApiGateway.SynchDataService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("apigateway/[action]")]
    [ApiController]
    public class ApiGatewayController : Controller
    {
        private readonly IApiGatewayRepo _repo;
        private readonly IApiGatewayDataClient _client;

        public ApiGatewayController(IApiGatewayRepo repo, IApiGatewayDataClient client )
        {
            _repo = repo;
            _client = client;
        }

        [HttpGet]
        [ActionName("GetRoomLayout")]
        public async Task<ActionResult<string>> GetRoomLayout()
        {   
            try{
               var response = await _client.GetHomeLayout();
               return Ok(response);
            }
            catch(Exception e)
            {
                Console.WriteLine($"---->{e}");
            }
            return NotFound();
        }

        [HttpPost()]
        [ActionName("NotificationTimer")]
        public ActionResult<NotificationReadDto> GetNotificationTimer(NotificationReadDto notifDto)
        {
            Console.WriteLine("---Notification received!");
            return Ok(notifDto);
        }

        [HttpPost()]
        [ActionName("CreateUser")]
        public async Task CreateUser(UserReadDto userDto)
        {
            try
            {
               await _client.CreateUser(userDto);
            }
            catch(Exception e)
            {
                Console.WriteLine($"---->{e}");
            }
        }

        [HttpPost()]
        [ActionName("ChangeSmartDeviceId")]
        public async Task ChangeSmartDeviceId(ChangeIds userDto)
        {
            try
            {
               await _client.ChangeSmartDeviceId(userDto);
            }
            catch(Exception e)
            {
                Console.WriteLine($"---->{e}");
            }
        }

        [HttpPost()]
        [ActionName("CreateNewRoom")]
        public async Task CreateNewRoom(RoomReadDto roomDto)
        {
            try
            {
               await _client.CreateRoom(roomDto);
            }
            catch(Exception e)
            {
                Console.WriteLine($"---->{e}");
            }
        }

        [HttpPost()]
        [ActionName("AddNewDevice")]
        public async Task AddNewDevice(DeviceReadDto deviceRead)
        {
            try
            {
               await _client.AddNewDevice(deviceRead);
            }
            catch(Exception e)
            {
                Console.WriteLine($"---->{e}");
            }
        }

        [HttpGet()]
        [ActionName("GetAllUsers")]
        public async Task<ActionResult<string>> GetAllUsers()
        {
                var content = await _client.GetAllUsers();
                
                return Ok(content); 
        }

        [HttpGet()]
        [ActionName("GetAllNotification")]
        public async Task<ActionResult<string>> GetAllNotifications()
        {
                var content = await _client.GetAllNotifications();
                
                return Ok(content); 
        }

        [HttpGet()]
        [ActionName("GetAllDevices")]
        public async Task<ActionResult<string>> GetAllDevices()
        {
                var content = await _client.GetAllDevices();
                
                return Ok(content); 
        }
        
        [HttpPost()]
        [ActionName("login")]
        public async Task<ActionResult<UserReadDto>> Login(Login obj)
        {
            try
            {
               var content = await _client.Login(obj);
               return Ok(content);
            }
            catch(Exception e)
            {
                Console.WriteLine($"---->{e}");
            } 
            return NotFound();
        }
    }
}