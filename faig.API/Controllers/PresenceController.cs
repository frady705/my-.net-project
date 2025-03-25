using AutoMapper;
using faig.API.Models;
using faig.Core.DTOs;
using faig.Core.Entities;
using faig.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace faig.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceController : ControllerBase
    {
        private readonly IPresenceService _presenceService;
        private readonly IMapper _mapper;
        public PresenceController(IPresenceService presenceService,IMapper mapper)
        {
            _presenceService = presenceService;
            _mapper = mapper;
        }

        // GET: api/<presenceController>
        [HttpGet]
        public ActionResult Get()
        {
            var list = _presenceService.GetList();
            var listDto = _mapper.Map<IEnumerable<PresenceDto>>(list);
            return Ok(listDto);
        }

        // GET api/<presenceController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var presence = _presenceService.GetById(id);
            var presenceDto = _mapper.Map<UserDto>(presence);
            return Ok(presenceDto);
        }

        // POST api/<presenceController>
        [HttpPost]
        public ActionResult Post([FromBody] PresencePostModel presence)
        {
            var presenceToPost = new Presence {UserId=presence.UserId,Date=presence.Date,EntryTime=presence.EntryTime,DepartureTime=presence.DepartureTime,AttendanceStatus=presence.AttendanceStatus };
            var newPresence = _presenceService.Add(presenceToPost);
            return Ok(newPresence);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PresencePostModel presence)
        {
            var presenceToPut = new Presence {  Date = presence.Date, EntryTime = presence.EntryTime, DepartureTime = presence.DepartureTime, AttendanceStatus = presence.AttendanceStatus };

            var updatedPresence = _presenceService.Update(presenceToPut);
            return Ok(updatedPresence);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _presenceService.Delete(id);
            return Ok();
        }
    }
}