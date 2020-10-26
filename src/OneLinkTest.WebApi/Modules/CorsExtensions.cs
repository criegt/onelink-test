using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace OneLinkTest.WebApi.Modules
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsAndPolicy(this IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy("AngularClientPolicy",
                        builder => builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                });
            return services;
        }

        public static IApplicationBuilder UseCorsAndPolicy(this IApplicationBuilder app)
        {
            app.UseCors("AngularClientPolicy");
            return app;
        }
    }
}
