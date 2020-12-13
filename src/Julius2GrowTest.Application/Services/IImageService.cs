using System.IO;
using System.Threading.Tasks;
using OneOf;
using OneOf.Types;

namespace Julius2GrowTest.Application.Services
{
    public interface IImageService
    {
        string CreateUri(string name);
        Task<OneOf<Success, Error<string>>> RemoveAsync(string name);
        Task<OneOf<Success, Error<string>>> UploadAsync(string name, Stream image);
    }
}
