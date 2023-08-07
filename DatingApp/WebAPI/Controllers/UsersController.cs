using WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("webapi/[controller]")] // /WebApi/users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
    }
}