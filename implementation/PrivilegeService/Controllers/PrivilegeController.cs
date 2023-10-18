using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrivilegeService.AsyncCommunication;
using PrivilegeService.Data;
using PrivilegeService.Dto;
using PrivilegeService.Models;

namespace PrivilegeService.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class PrivilegeController : Controller
    {
        private readonly IPrivilegeRepo _repo;
        private readonly IMapper _mapper;
        private readonly IMessageBus _messageBus;

        public PrivilegeController(IPrivilegeRepo repo, IMapper map, IMessageBus messageBus)
        {
            _repo = repo;
            _mapper = map;
            _messageBus = messageBus;
        }

        [HttpGet]
        [ActionName("GetAllUsers")]
        public async Task<ActionResult<List<PrivilegeReadDto>>> GetUsers()
        {
            Console.WriteLine("----------> Getting notifications....");
        
            var notificationItem = _repo.GetUsers();


            return Ok(_mapper.Map<IEnumerable<PrivilegeReadDto>>(notificationItem));
        }

        [HttpPost]
        [ActionName("login")]
        public ActionResult<PrivilegeReadDto> Login(Login login)
        {
            return Ok(_repo.LogIn(login.Username, login.Password));
        }

        [HttpPost]
        [ActionName("publishUser")]
        public ActionResult CreateUser(PrivilegeCreateDto privilegeCreate)
        {
            var privilegeCreated = _mapper.Map<Privilege>(privilegeCreate);

            _repo.CreateUser(privilegeCreated);
            _repo.SaveChanges();
            
            var privilegeReadDto = _mapper.Map<PrivilegeReadDto>(privilegeCreated);

            try
            {
                var publishedPrivilege = _mapper.Map<PrivilegePublish>(privilegeReadDto);
                _messageBus.PublishUSer(publishedPrivilege);
            }
            catch(Exception e)
            {
                Console.WriteLine($"asdiasdasidjasidjasidjasidjaisdiasj----->{e}");
            }
            
            return Ok("---> Created new user!");
        }
    }
}