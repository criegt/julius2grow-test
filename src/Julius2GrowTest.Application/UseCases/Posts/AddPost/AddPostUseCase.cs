using System;
using System.IO;
using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Domain.Posts;

namespace Julius2GrowTest.Application.UseCases.Posts.AddPost
{
    public class AddPostUseCase : IAddPostUseCase
    {
        private readonly IPostRepository _postRepository;
        private readonly IImageService _imageService;
        private readonly Notification _notification;
        private IOutputPort _outputPort;

        public AddPostUseCase(IPostRepository postRepository,
            IImageService imageService,
            Notification notification)
        {
            _postRepository = postRepository;
            _imageService = imageService;
            _notification = notification;
            _outputPort = new AddPostPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task ExecuteAsync(string userId, string title, string content, Stream image)
        {
            var post = new Post
            {
                Title = title,
                Content = content,
                CreatedAt = DateTime.Now,
                UserId = userId,
                Image = $"{Guid.NewGuid()}.jpg"
            };

            var result = await _imageService.UploadAsync(post.Image, image);

            if (result.IsT1)
            {
                _notification.Add("Detail", result.AsT1.Value);
                _outputPort.Error();

                return;
            }

            await _postRepository.AddAsync(post);

            _outputPort.Ok();
        }
    }
}
