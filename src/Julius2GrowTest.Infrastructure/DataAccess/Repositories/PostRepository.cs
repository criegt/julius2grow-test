using System.Linq;
using System.Threading.Tasks;
using Julius2GrowTest.Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace Julius2GrowTest.Infrastructure.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly Julius2GrowTestContext _context;

        public PostRepository(Julius2GrowTestContext context)
        {
            _context = context;
        }

        public async Task<Post> GetAsync(int id)
        {
            return await _context.Posts
                .Where(p => p.Id == id)
                .Select(p => new Post
                {
                    Id = p.Id,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    Image = p.Image,
                    Title = p.Title,
                    UserId = p.ApplicationUserId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PaginatedPosts> GetPaginatedByUserAsync(string userId, int pageIndex = 0, int pageSize = 10, string searchTerms = "")
        {
            var query = _context.Posts
                .Where(p => p.Title.ToLower().Contains(searchTerms.ToLower()));

            var count = await query.CountAsync();
            var items = await query.Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select(p => new Post
                {
                    Id = p.Id,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    Image = p.Image,
                    Title = p.Title,
                    UserId = p.ApplicationUserId
                })
                .AsNoTracking()
                .ToListAsync();

            return new PaginatedPosts(items, count, pageIndex, pageSize);
        }

        public async Task AddAsync(Post post)
        {
            _context.Posts.Add(new()
            {
                Id = post.Id,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Image = post.Image,
                Title = post.Title,
                ApplicationUserId = post.UserId
            });

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post is null)
            {
                return;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
