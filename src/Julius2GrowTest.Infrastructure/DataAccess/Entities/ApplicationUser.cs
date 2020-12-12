using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Julius2GrowTest.Infrastructure.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<Post> Posts { get; set; }
    }
}
