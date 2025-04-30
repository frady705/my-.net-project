using AutoMapper;
using faig.API.Models;
using faig.Core.DTOs;
using faig.Core.Entities;
using faig.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace faig.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<userController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list=await _userService.GetListAsync();
            var listDto = _mapper.Map<IEnumerable<UserDto>>(list);
            return Ok(listDto);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user =await _userService.GetByIdAsync(id);
            var userDto= _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserPostModel user)
        {
            var userToAdd=new User {Name=user.Name,Role=user.Role,Email=user.Email,Password=user.Password};
            var newUser =await _userService.AddAsync(userToAdd);
            return Ok(newUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserPostModel user)
        {
            var userToPut = new User {Password = user.Password };

            var updatedUser = await _userService.UpdateAsync(userToPut);
            return Ok(updatedUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
           await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}