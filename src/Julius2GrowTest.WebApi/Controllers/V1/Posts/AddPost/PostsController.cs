using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Application.UseCases.Posts.AddPost;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Julius2GrowTest.WebApi.Controllers.V1.Posts.AddPost
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;

        public PostsController(Notification notification)
        {
            _notification = notification;
        }

        void IOutputPort.Error()
        {
            var problemDetails = new ProblemDetails
            {
                Detail = _notification.ModelState["Detail"].FirstOrDefault()
            };
            _viewModel = StatusCode(StatusCodes.Status500InternalServerError, problemDetails);
        }

        void IOutputPort.Ok() => _viewModel = Ok();

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AddPostRequest request,
            [FromServices] IAddPostUseCase useCase)
        {
            useCase.SetOutputPort(this);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await useCase.ExecuteAsync(userId,
                request.Title,
                request.Content,
                request.Image.OpenReadStream())
                .ConfigureAwait(false);

            return _viewModel;
        }
    }
}
