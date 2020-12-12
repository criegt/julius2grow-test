using System.Threading.Tasks;

namespace Julius2GrowTest.Application.UseCases.Posts.GetPosts
{
    public interface IGetPostsUseCase
    {
        Task ExecuteAsync(string userId, int pageIndex, int pageSize, string searchTerms);
        void SetOutputPort(IOutputPort outputPort);
    }
}