using System.Threading.Tasks;

namespace Julius2GrowTest.Application.UseCases.Users.SignUpUser
{
    public interface ISignUpUserUseCase
    {
        Task ExecuteAsync(string userName, string email, string password);
        void SetOutputPort(IOutputPort outputPort);
    }
}