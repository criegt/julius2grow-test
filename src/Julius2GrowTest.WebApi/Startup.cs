using Julius2GrowTest.Infrastructure.Identity;
using Julius2GrowTest.Infrastructure.S3;
using Julius2GrowTest.WebApi.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Julius2GrowTest.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtBearerOptions>(Configuration.GetSection(JwtBearerOptions.JwtBearer));
            services.Configure<S3Options>(Configuration.GetSection(S3Options.S3));

            services.AddEntityFramework(Configuration);
            services.AddIdentity(Configuration);
            services.AddUseCasesAndServices();

            services.AddControllers();
            services.AddCorsAndPolicy();
            services.AddVersioning();
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerAndConfigure(Configuration, provider);
            }

            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCorsAndPolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
