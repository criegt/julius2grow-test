using System;
using System.Collections.Generic;

namespace Julius2GrowTest.Domain.Posts
{
    public class PaginatedPosts
    {
        public int PageIndex { get; }

        public int TotalPages { get; }

        public List<Post> Posts { get; }

        public bool HasPreviousPage => (PageIndex > 0);

        public bool HasNextPage => (PageIndex + 1 < TotalPages);

        public PaginatedPosts(IEnumerable<Post> posts, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Posts = new(posts);
        }
    }
}
