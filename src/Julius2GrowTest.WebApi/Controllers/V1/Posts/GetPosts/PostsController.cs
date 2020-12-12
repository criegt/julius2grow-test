using System.Security.Claims;
using System.Threading.Tasks;
using Julius2GrowTest.Application.UseCases.Posts.GetPosts;
using Julius2GrowTest.Domain.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Julius2GrowTest.WebApi.Controllers.V1.Posts.GetPosts
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase, IOutputPort
    {
        private IActionResult _viewModel;

        void IOutputPort.Ok(PaginatedPosts posts) => _viewModel = Ok(posts);

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IGetPostsUseCase useCase,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchTerms = "")
        {
            useCase.SetOutputPort(this);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await useCase.ExecuteAsync(userId,
                pageIndex,
                pageSize,
                searchTerms)
                .ConfigureAwait(false);

            return _viewModel;
        }
    }
}
