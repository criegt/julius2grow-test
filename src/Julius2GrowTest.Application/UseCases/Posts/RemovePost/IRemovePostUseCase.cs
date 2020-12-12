using System.Threading.Tasks;

namespace Julius2GrowTest.Application.UseCases.Posts.RemovePost
{
    public interface IRemovePostUseCase
    {
        Task ExecuteAsync(string userId, int postId);
        void SetOutputPort(IOutputPort outputPort);
    }
}