using System.Threading.Tasks;
using Julius2GrowTest.Domain.Users;
using OneOf;
using OneOf.Types;

namespace Julius2GrowTest.Application.Services
{
    public interface IUserService
    {
        Task<OneOf<Success, Error<string>>> SignUpAsync(User user, string password);
        Task<OneOf<Success, Error<string>>> SignInAsync(string userName, string password);
        string CreateToken(User user);
    }
}
