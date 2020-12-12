using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Domain.Users;

namespace Julius2GrowTest.Application.UseCases.Users.SignUpUser
{
    public class SignUpUserUseCase : ISignUpUserUseCase
    {
        private readonly IUserService _userService;
        private readonly Notification _notification;
        private IOutputPort _outputPort;

        public SignUpUserUseCase(IUserService userService, Notification notification)
        {
            _userService = userService;
            _notification = notification;
            _outputPort = new SignUpUserPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(string userName, string email, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName
            };

            var result = await _userService.SignUpAsync(user, password);

            result.Switch(
                ok => _outputPort.Ok(),
                error =>
                {
                    _notification.Add("Detail", error.Value);
                    _outputPort.Conflict();
                });
        }
    }
}
