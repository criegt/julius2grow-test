using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Domain.Posts;

namespace Julius2GrowTest.Application.UseCases.Posts.RemovePost
{
    public class RemovePostUseCase : IRemovePostUseCase
    {
        private readonly IPostRepository _postRepository;
        private readonly IImageService _imageService;
        private readonly Notification _notification;
        private IOutputPort _outputPort;

        public RemovePostUseCase(IPostRepository postRepository,
            IImageService imageService,
            Notification notification)
        {
            _postRepository = postRepository;
            _imageService = imageService;
            _notification = notification;
            _outputPort = new RemovePostPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(string userId, int postId)
        {
            var post = await _postRepository.GetAsync(postId);

            if (post is null || post.UserId != userId)
            {
                _outputPort.NotFound();

                return;
            }

            var result = await _imageService.RemoveAsync(post.Image);

            if (result.IsT1)
            {
                _notification.Add("Detail", result.AsT1.Value);
                _outputPort.Error();

                return;
            }

            await _postRepository.RemoveAsync(postId);

            _outputPort.Ok();
        }
    }
}
