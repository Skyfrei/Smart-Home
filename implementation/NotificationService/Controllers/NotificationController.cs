using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationService.AsyncCommunication;
using NotificationService.Data;
using NotificationService.Dtos;
using NotificationService.Models;
using NotificationService.SynchDataService.Http;

namespace NotificationService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepo _repository;
        private readonly IMapper _mapper;
        private readonly INotificationDataClient _client;
        private readonly IMessageBus _messageBus;

        public NotificationController(INotificationRepo repo, IMapper mapper, INotificationDataClient client, IMessageBus messageBus)
        {
            _repository = repo;
            _mapper = mapper;
            _client = client;
            _messageBus = messageBus;
        }

        [HttpGet]
        [ActionName("GetAllNotifications")]
        public ActionResult<IEnumerable<NotificationReadDto>> GetNotifications()
        {
            Console.WriteLine("----------> Getting notifications....");
        
            var notificationItem = _repository.GetAllNotifications();


            return Ok(_mapper.Map<IEnumerable<NotificationReadDto>>(notificationItem));
        }

        [HttpGet("{id}", Name = "GetNotificationById")]
        public ActionResult<NotificationReadDto> GetNotificationById(int id)
        {
            var notificationItem = _repository.GetNotificationById(id);

            if (notificationItem != null)
            {
                return Ok(_mapper.Map<NotificationReadDto>(notificationItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<NotificationReadDto>> CreateNotification(NotificationCreateDto notificationCreateDto)
        {
            var notificationCreated = _mapper.Map<Notification>(notificationCreateDto);

            _repository.CreateNotification(notificationCreated);
            _repository.SaveChanges();
            
            var notificationReadDto = _mapper.Map<NotificationReadDto>(notificationCreated);

            try
            {
                var publishedNotification = _mapper.Map<NotificationPublish>(notificationReadDto);
                publishedNotification.NotificationDetails = "Test";
                _messageBus.PublishNotification(publishedNotification);
            }
            catch(Exception e)
            {
                Console.WriteLine($"asdiasdasidjasidjasidjasidjaisdiasj----->{e}");
            }

            // try
            // {
            //     await _client.SendNotificationToHomeLayout(notificationReadDto);
            // }
            // catch(Exception e)
            // {
            //     Console.WriteLine($"--> Didnt work chief. {e}");
            // }

            return CreatedAtRoute(nameof(GetNotificationById), new { Id = notificationReadDto.Id}, notificationReadDto);
        }
    }
}