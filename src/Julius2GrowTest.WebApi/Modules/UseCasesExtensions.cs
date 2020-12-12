using Julius2GrowTest.Application.Services;
using Julius2GrowTest.Application.UseCases.Posts.AddPost;
using Julius2GrowTest.Application.UseCases.Posts.GetPosts;
using Julius2GrowTest.Application.UseCases.Posts.RemovePost;
using Julius2GrowTest.Application.UseCases.Users.SignInUser;
using Julius2GrowTest.Application.UseCases.Users.SignUpUser;
using Julius2GrowTest.Domain.Posts;
using Julius2GrowTest.Domain.Users;
using Julius2GrowTest.Infrastructure.DataAccess.Repositories;
using Julius2GrowTest.Infrastructure.Identity.Repositories;
using Julius2GrowTest.Infrastructure.Identity.Services;
using Julius2GrowTest.Infrastructure.S3.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Julius2GrowTest.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCasesAndServices(this IServiceCollection services)
        {
            services.AddScoped<Notification>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ISignUpUserUseCase, SignUpUserUseCase>();
            services.AddScoped<ISignInUserUseCase, SignInUserUseCase>();
            services.AddScoped<IAddPostUseCase, AddPostUseCase>();
            services.AddScoped<IGetPostsUseCase, GetPostsUseCase>();
            services.AddScoped<IRemovePostUseCase, RemovePostUseCase>();

            return services;
        }
    }
}
