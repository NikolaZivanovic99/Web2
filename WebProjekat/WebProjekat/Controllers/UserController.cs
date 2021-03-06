using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Services;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUpdateUserDto userDto)
        {
            try
            {
                return Created("/api/User",_userService.AddUser(userDto));
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception) 
            {
                return NotFound();
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult UpadateUser(long id, [FromBody] AddUpdateUserDto userDto)
        {
            try
            {
                return Created("/api/User",_userService.UpadateUser(id, userDto));
            }
            catch (Exception) 
            {
                return BadRequest();
            }
           
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest login)
        {
            try
            {
                LoginResponse loginResponse = _userService.Login(login);
                return Created("/api/User/login", loginResponse);
            }
            catch (Exception)
            {
                return NotFound();
            }
            

        }
    }
}
