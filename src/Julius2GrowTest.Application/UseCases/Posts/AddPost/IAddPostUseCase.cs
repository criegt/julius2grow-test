using System.IO;
using System.Threading.Tasks;

namespace Julius2GrowTest.Application.UseCases.Posts.AddPost
{
    public interface IAddPostUseCase
    {
        Task ExecuteAsync(string userId, string title, string content, Stream image, string extension);
        void SetOutputPort(IOutputPort outputPort);
    }
}
