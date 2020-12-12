using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Application.UseCases.Users.SignUpUser;
using Microsoft.AspNetCore.Mvc;

namespace Julius2GrowTest.WebApi.Controllers.V1.Users.SignUpUser
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

        void IOutputPort.Conflict()
        {
            var problemDetails = new ProblemDetails
            {
                Detail = _notification.ModelState["Detail"].FirstOrDefault()
            };
            _viewModel = Conflict(problemDetails);
        }

        void IOutputPort.Ok() => _viewModel = NoContent();

        [HttpPost("SignUp")]
        public async Task<IActionResult> Post(
            [FromServices] ISignUpUserUseCase useCase,
            [FromBody][Required] SignUpUserRequest request)
        {
            useCase.SetOutputPort(this);

            await useCase.ExecuteAsync(request.UserName, request.Email, request.Password)
                .ConfigureAwait(false);

            return _viewModel;
        }
    }
}
