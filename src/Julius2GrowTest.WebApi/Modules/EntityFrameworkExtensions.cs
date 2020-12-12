using Julius2GrowTest.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Julius2GrowTest.WebApi.Modules
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Julius2GrowTestContext>(options =>
                options.UseInMemoryDatabase("Julius2GrowTestDb"));
            return services;
        }
    }
}
