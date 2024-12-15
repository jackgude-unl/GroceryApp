using Microsoft.AspNetCore.Mvc;
using Accessors.Classes;
using Accessors.Interfaces;
using System.Collections.Generic;
using System;

namespace GroceryAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAccessor _userAccessor;

        public UsersController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                IEnumerable<User> users = _userAccessor.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                User user = _userAccessor.GetUserById(id);
                if (user == null)
                {
                    return NotFound(new { error = "User not found." });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AddUser(User user, string password)
        {
            try
            {
                bool success = _userAccessor.AddUserToDb(user, password);
                if (!success)
                {
                    return BadRequest(new { error = "Failed to add user." });
                }
                return Ok(new { message = "User added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
