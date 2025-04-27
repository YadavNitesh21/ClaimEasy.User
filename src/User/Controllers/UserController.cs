using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using User.Db;
using User.Models;
using User.DTOs;

namespace User.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize] // All endpoints require a valid token
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        // Create User Profile
        [HttpPost("profile")]
        public async Task<IActionResult> CreateProfile([FromBody] CreateUserProfileDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized("Invalid token.");

            var profile = new UserProfile
            {
                Id = Guid.Parse(userId),
                Username = User.Identity.Name,   // Optional
                FirstName = dto.FrstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                Age = dto.Age,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                Email = User.FindFirst(ClaimTypes.Email)?.Value, // Optional if added to token
                Phone = User.FindFirst(ClaimTypes.MobilePhone)?.Value // Optional if needed
            };

            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return Ok(profile);
        }


    }
}
