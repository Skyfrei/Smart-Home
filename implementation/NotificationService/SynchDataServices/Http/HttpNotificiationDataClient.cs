using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NotificationService.Dtos;

namespace NotificationService.SynchDataService.Http
{
    public class HttpNotificationDataClient : INotificationDataClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public HttpNotificationDataClient(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task SendNotificationToHomeLayout(NotificationReadDto notifReadDto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(notifReadDto),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _client.PostAsync($"{_config["HomeLayout"]}", content);
        
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("-------Sync POST to HomeLayout Worked.------");
            }
            else
            {
                Console.WriteLine("------Nay it failed to post to homelayout.-------");
            }
        }
    }
}