using System.Threading.Tasks;
using Julius2GrowTest.Domain.Posts;

namespace Julius2GrowTest.Application.UseCases.Posts.GetPosts
{
    public class GetPostsUseCase : IGetPostsUseCase
    {
        private readonly IPostRepository _postRepository;
        private IOutputPort _outputPort;

        public GetPostsUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _outputPort = new GetPostsPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(string userId, int pageIndex, int pageSize, string searchTerms)
        {
            var posts = await _postRepository.GetPaginatedByUserAsync(userId, pageIndex, pageSize, searchTerms);

            _outputPort.Ok(posts);
        }
    }
}
