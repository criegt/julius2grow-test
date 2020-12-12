using System.Threading.Tasks;
using Julius2GrowTest.Domain.Users;
using Julius2GrowTest.Infrastructure.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Julius2GrowTest.Infrastructure.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
            {
                return null;
            }

            return new()
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName
            };
        }
    }
}
