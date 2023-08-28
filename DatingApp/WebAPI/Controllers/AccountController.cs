using WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebAPI.Entities;
using System.Text;
using WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;

        }

        [HttpPost("register")] // POST: webapi/accounts/register
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}