using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeBasedService.DataTransferObject;

namespace TimeBasedService.SynchDataService.Http
{
    public class HttpTimeBasedServiceClient : ITimeBasedServiceClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public HttpTimeBasedServiceClient(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        
    }
}