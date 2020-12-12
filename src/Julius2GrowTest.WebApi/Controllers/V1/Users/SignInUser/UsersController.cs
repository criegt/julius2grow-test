using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Application.UseCases.Users.SignInUser;
using Microsoft.AspNetCore.Mvc;

namespace Julius2GrowTest.WebApi.Controllers.V1.Users.SignInUser
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;

        public UsersController(Notification notification)
        {
            _notification = notification;
        }

        void IOutputPort.Invalid()
        {
            var problemDetails = new ProblemDetails
            {
                Detail = _notification.ModelState["Detail"].FirstOrDefault()
            };
            _viewModel = Conflict(problemDetails);
        }

        void IOutputPort.Ok(UserSigned userSigned) => _viewModel = Ok(userSigned);

        [HttpPost("SignIn")]
        public async Task<IActionResult> Post(
            [FromServices] ISignInUserUseCase useCase,
            [FromBody][Required] SignInUserRequest request)
        {
            useCase.SetOutputPort(this);

            await useCase.ExecuteAsync(request.UserName, request.Password)
                .ConfigureAwait(false);

            return _viewModel;
        }
    }
}
