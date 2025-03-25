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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<userController>
        [HttpGet]
        public ActionResult Get()
        {
            var list=_userService.GetList();
            var listDto = _mapper.Map<IEnumerable<UserDto>>(list)
            return Ok(listDto);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            var userDto= _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] UserPostModel user)
        {
            var userToAdd=new User {Name=user.Name,Role=user.Role,Email=user.Email,Password=user.Password,UserName=user.UserName };
            var newUser = _userService.Add(userToAdd);
            return Ok(newUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserPostModel user)
        {
            var userToPut = new User {Password = user.Password, UserName = user.UserName };

            var updatedUser = _userService.Update(userToPut);
            return Ok(updatedUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}