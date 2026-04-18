using AutoMapper;
using CommandService.DTO;
using CommandService.Models;
using CommandService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepository _repository;
        private readonly IMapper _mapper;
        public PlatformsController(ICommandRepository _repository,IMapper _mapper)
        {
            this._repository = _repository;
            this._mapper = _mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>>GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from Command Service");
            var platformItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItems));
        }


        //[HttpPost]
        //public ActionResult TestInboundConnection()
        //{
        //    Console.WriteLine("--> Inbound POST # Command Service");
        //    return Ok("Inbound test of from Platforms Controller");
        //}
    }
}
