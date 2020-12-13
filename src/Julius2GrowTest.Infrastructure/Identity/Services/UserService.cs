using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Domain.Users;
using Julius2GrowTest.Infrastructure.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneOf;
using OneOf.Types;

namespace Julius2GrowTest.Infrastructure.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOptions<JwtBearerOptions> _options;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtBearerOptions> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options;
        }

        public (string, int) CreateToken(User user)
        {
            var claims = new[]
{
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddSeconds(_options.Value.ExpiresIn);

            var token = new JwtSecurityToken(
                _options.Value.Issuer,
                _options.Value.Audience,
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), _options.Value.ExpiresIn);
        }

        public async Task<OneOf<Success, Error<string>>> SignInAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

            return result.Succeeded ? new Success() : new Error<string>("User name or password are invalid");
        }

        public async Task<OneOf<Success, Error<string>>> SignUpAsync(User user, string password)
        {
            var newUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email
            };
            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault()?.Description ?? string.Empty;

                return new Error<string>(error);
            }

            return new Success();
        }
    }
}
