using Julius2GrowTest.Domain.Posts;

namespace Julius2GrowTest.Application.UseCases.Posts.GetPosts
{
    public interface IOutputPort
    {
        void Ok(PaginatedPosts posts);
    }
}
