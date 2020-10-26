using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OneLinkTest.Application.Services;
using OneLinkTest.Application.UseCases.Areas.GetAreas;
using OneLinkTest.Application.UseCases.Employees.AddEmployee;
using OneLinkTest.Application.UseCases.Employees.GetEmployee;
using OneLinkTest.Application.UseCases.Employees.GetEmployees;
using OneLinkTest.Application.UseCases.Employees.UpdateEmployee;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Domain.Employees;
using OneLinkTest.Infrastructure.DataAccess;
using OneLinkTest.Infrastructure.DataAccess.Repositories;
using OneLinkTest.WebApi.Modules;

namespace OneLinkTest.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCorsAndPolicy();
            services.AddVersioning();
            services.AddSwagger();
            services.AddSqlServer(Configuration);
            services.AddUseCases();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCorsAndPolicy();
            app.UseSwaggerAndConfigure(Configuration, provider);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
