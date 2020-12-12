using System.Threading.Tasks;

namespace Julius2GrowTest.Domain.Posts
{
    public interface IPostRepository
    {
        Task<Post> GetAsync(int id);
        Task<PaginatedPosts> GetPaginatedByUserAsync(string userId, int pageIndex = 0, int pageSize = 10, string searchTerms = "");
        Task AddAsync(Post post);
        Task RemoveAsync(int id);
    }
}
