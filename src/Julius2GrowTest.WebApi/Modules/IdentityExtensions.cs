using System.Text;
using Julius2GrowTest.Infrastructure.DataAccess;
using Julius2GrowTest.Infrastructure.DataAccess.Entities;
using Julius2GrowTest.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Julius2GrowTest.WebApi.Modules
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<Julius2GrowTestContext>();

            var jwtBearerOptions = configuration.GetSection(JwtBearerOptions.JwtBearer)
                .Get<JwtBearerOptions>();
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtBearerOptions.Issuer,
                        ValidAudience = jwtBearerOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearerOptions.SecurityKey))
                    };
                });

            return services;
        }
    }
}
