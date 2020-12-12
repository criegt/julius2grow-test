using System.Threading.Tasks;

namespace Julius2GrowTest.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string userName);
    }
}
