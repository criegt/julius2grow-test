using Julius2GrowTest.Domain.Posts;

namespace Julius2GrowTest.Application.UseCases.Posts.GetPosts
{
    public class GetPostsPresenter : IOutputPort
    {
        public PaginatedPosts Posts { get; private set; }

        public void Ok(PaginatedPosts posts) => Posts = posts;
    }
}
