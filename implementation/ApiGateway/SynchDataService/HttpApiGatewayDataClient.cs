using System.Text;
using System.Text.Json;
using ApiGateway.Dto;

namespace ApiGateway.SynchDataService
{
    public class HttpApiGatewayDataClient : IApiGatewayDataClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public HttpApiGatewayDataClient(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task AddNewDevice(DeviceReadDto deviceReadDto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(deviceReadDto),
                Encoding.UTF8,
                "application/json"
            );
            try
            {
                var response = await _client.PostAsync($"{_config["HomeLayout"]}addnewdevice", content);
                 Console.WriteLine("--- Creating new room");
            }
            catch(Exception e)
            {
                Console.WriteLine($"----{e}");
            } 
        }

        public async Task ChangeSmartDeviceId(ChangeIds roomDto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(roomDto),
                Encoding.UTF8,
                "application/json"
            );
            try
            {
                var response = await _client.PostAsync($"{_config["HomeLayout"]}ChangeRoomSmartDevice", content);
                 Console.WriteLine("--- Changing smart device in room");
            }
            catch(Exception e)
            {
                Console.WriteLine($"----{e}");
            } 
        }

        public async Task CreateNotification(NotificationReadDto readDto)
        {
            //
        }

        public async Task CreateRoom(RoomReadDto roomDto)
        {
           var content = new StringContent(
                JsonSerializer.Serialize(roomDto),
                Encoding.UTF8,
                "application/json"
            );
            try
            {
                var response = await _client.PostAsync($"{_config["HomeLayout"]}createnewroom", content);
                 Console.WriteLine("--- Creating new room");
            }
            catch(Exception e)
            {
                Console.WriteLine($"----{e}");
            } 
        }

        public async Task CreateUser(UserReadDto userDto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(userDto),
                Encoding.UTF8,
                "application/json"
            );
            try
            {
                var response = await _client.PostAsync($"{_config["Privilege"]}publishUser", content);
                 Console.WriteLine("--- Creating new user");
            }
            catch(Exception e)
            {
                Console.WriteLine($"----{e}");
            }
        }

        public async Task<string> GetAllDevices()
        {
            try
            {
                var response = await _client.GetAsync($"{_config["HomeLayout"]}getalldevices");
                Console.WriteLine("--- Getting devices!");
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"---{e}");
            }
            return "";
        }

        public async Task<string> GetAllNotifications()
        {
            Console.WriteLine($"======================================={_config["Notification"]}getallnotifications");
            try
            {
               
                var response = await _client.GetAsync($"{_config["Notification"]}getallnotifications");
                Console.WriteLine("--- Getting notifications!");
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"---{e}");
            }
            return "";
        }

        public async Task<string> GetAllUsers()
        {
            try
            {
                var response = await _client.GetAsync($"{_config["Privilege"]}getallusers");
                Console.WriteLine("--- Getting users!");
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"---{e}");
            }
            return "";
        }

        public async Task<string> GetHomeLayout()
        {
            
            try
            {
                var response = await _client.GetAsync($"{_config["HomeLayout"]}getallrooms");
                Console.WriteLine("--- Getting rooms!");
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"---{e}");
            }
            return "";
        }

        public async Task<UserReadDto> Login(Login obj)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(obj),
                Encoding.UTF8,
                "application/json"
            );
            Console.WriteLine(content);

            try
            {
                var response = await _client.PostAsync($"{_config["Privilege"]}login", content);
                Console.WriteLine("--- Sent notification to Privilege Service");
                // var responseString = response.Content.ReadFromJsonAsync();
                // UserReadDto? obj2 = JsonSerializer.Deserialize<UserReadDto>(responseString.ToString());
                UserReadDto obj2 = new UserReadDto()
                {
                    Id = 2,
                    Username = "maxx",
                    Password = "1234",
                    UserRole = Role.User,
                    Email = "max@oncoffe.com"
                };
                return obj2;
            }
            catch(Exception e)
            {
                Console.WriteLine($"----{e}");
            }
            UserReadDto er = null;
            return er;
        }
    }
}