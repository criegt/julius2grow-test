using Julius2GrowTest.Infrastructure.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Julius2GrowTest.Infrastructure.DataAccess
{
    public class Julius2GrowTestContext : IdentityDbContext
    {
        public Julius2GrowTestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
