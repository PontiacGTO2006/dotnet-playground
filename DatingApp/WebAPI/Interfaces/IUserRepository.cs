using WebAPI.Entities;

namespace WebAPI.Interfaces
{
    public interface IUserRepository
    {
         void Update(AppUser user);
         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppUser>> GetUsersAsync();
         Task<AppUser> GetUserByIdAsaync(int id);
         Task<AppUser> GetUserByUsername(string username);
    }
}