using System.Threading.Tasks;

namespace Julius2GrowTest.Application.UseCases.Users.SignInUser
{
    public interface ISignInUserUseCase
    {
        Task ExecuteAsync(string userName, string password);
        void SetOutputPort(IOutputPort outputPort);
    }
}
