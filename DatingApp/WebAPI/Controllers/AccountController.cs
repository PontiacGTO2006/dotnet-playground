using WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebAPI.Entities;
using System.Text;


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
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return user;
        }
    }
}