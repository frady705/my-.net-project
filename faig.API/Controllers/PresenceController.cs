using AutoMapper;
using faig.API.Models;
using faig.Core.DTOs;
using faig.Core.Entities;
using faig.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = "Manager")]

        public async Task<ActionResult> Get()
        {
            var list =await _presenceService.GetListAsync();
            var listDto = _mapper.Map<IEnumerable<PresenceDto>>(list);
            return Ok(listDto);
        }

        // GET api/<presenceController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Manager")]

        public async Task<ActionResult> Get(int id)
        {
            var presence =await _presenceService.GetByIdAsync(id);
            var presenceDto = _mapper.Map<UserDto>(presence);
            return Ok(presenceDto);
        }

        // POST api/<presenceController>
        [HttpPost]
        [Authorize]

        public async Task<ActionResult> Post([FromBody] PresencePostModel presence)
        {
            var presenceToPost = new Presence {UserId=presence.UserId,Date=presence.Date,EntryTime=presence.EntryTime,DepartureTime=presence.DepartureTime,AttendanceStatus=presence.AttendanceStatus };
            var newPresence =await _presenceService.AddAsync(presenceToPost);
            return Ok(newPresence);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [Authorize]

        public async Task<ActionResult> Put(int id, [FromBody] PresencePostModel presence)
        {
            var presenceToPut = new Presence {  Date = presence.Date, EntryTime = presence.EntryTime, DepartureTime = presence.DepartureTime, AttendanceStatus = presence.AttendanceStatus };

            var updatedPresence =await _presenceService.UpdateAsync(presenceToPut);
            return Ok(updatedPresence);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]

        public async Task<ActionResult> DeleteAsync(int id)
        {
           await _presenceService.DeleteAsync(id);
            return Ok();
        }
    }
}