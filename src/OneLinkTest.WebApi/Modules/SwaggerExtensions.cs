using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OneLinkTest.WebApi.Modules
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            return services;
        }

        public static IApplicationBuilder UseSwaggerAndConfigure(this IApplicationBuilder app, IConfiguration configuration, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        string swaggerEndpoint;

                        var basePath = configuration["ASPNETCORE_BASEPATH"];

                        if (!string.IsNullOrEmpty(basePath))
                        {
                            swaggerEndpoint = $"{basePath}/swagger/{description.GroupName}/swagger.json";
                        }
                        else
                        {
                            swaggerEndpoint = $"/swagger/{description.GroupName}/swagger.json";
                        }

                        options.SwaggerEndpoint(swaggerEndpoint, description.GroupName.ToUpperInvariant());
                    }
                });
            return app;
        }
    }
}
