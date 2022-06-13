using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dto;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }
        
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            return Ok(_adminService.GetAdmins());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_adminService.GetById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddAdmin([FromBody] AddUpdateAdminDto adminDto)
        {
            //try
            //{
                return Created("/api/User", _adminService.AddAdmin(adminDto));
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            try
            {
                _adminService.DeleteAdmin(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpadateAdmin(long id, [FromBody] AddUpdateAdminDto adminDto)
        {
            try
            {
                return Created("/api/User", _adminService.UpdateAdmin(id, adminDto));
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
                LoginResponse loginResponse = _adminService.Login(login);
                return Created("/api/User/login", loginResponse);
            }
            catch (Exception)
            {
                return NotFound();
            }


        }
    }
}
