using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeBasedService.AsyncCommunication;
using TimeBasedService.Data;
using TimeBasedService.Models;

namespace TimeBasedService.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TimeBasedServiceController : ControllerBase
    {
        private readonly ITimeBasedServiceRepo _repo;
        private readonly IMapper _mapper;
        private readonly IMessageBus _messageBus;

        public TimeBasedServiceController(ITimeBasedServiceRepo repo, IMapper map, IMessageBus messageBus)
        {
            _repo = repo;
            _mapper = map;
            _messageBus = messageBus;
        }

        // [HttpPost]
        // [ActionName("StartDeviceFunction")]
        // public ActionResult StartDeviceFunction(PrivilegeCreateDto privilegeCreate)
        // {
        //     var privilegeCreated = _mapper.Map<Privilege>(privilegeCreate);

        //     _repo.CreateUser(privilegeCreated);
        //     _repo.SaveChanges();
            
        //     var privilegeReadDto = _mapper.Map<PrivilegeReadDto>(privilegeCreated);

        //     try
        //     {
        //         var publishedPrivilege = _mapper.Map<PrivilegePublish>(privilegeReadDto);
        //         _messageBus.PublishUSer(publishedPrivilege);
        //     }
        //     catch(Exception e)
        //     {
        //         Console.WriteLine($"asdiasdasidjasidjasidjasidjaisdiasj----->{e}");
        //     }
            
        //     return Ok("---> Created new user!");
        // }

        
    }
}