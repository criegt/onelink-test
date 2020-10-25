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
using OneLinkTest.Application.UseCases.Employees.GetEmployees;
using OneLinkTest.Application.UseCases.Employees.UpdateEmployee;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Domain.Employees;
using OneLinkTest.Infrastructure.DataAccess;
using OneLinkTest.Infrastructure.DataAccess.Repositories;

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
            services.AddCors();
            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddSwaggerGen();

            services.AddDbContext<OneLinkTestContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("OneLinkTest")));
            services.AddScoped<Notification>();

            services.AddScoped<IAddEmployeeUseCase, AddEmployeeUseCase>();
            services.Decorate<IAddEmployeeUseCase, AddEmployeeValidationUseCase>();

            services.AddScoped<IUpdateEmployeeUseCase, UpdateEmployeeUseCase>();
            services.Decorate<IUpdateEmployeeUseCase, UpdateEmployeeValidationUseCase>();

            services.AddScoped<IGetEmployeesUseCase, GetEmployeesUseCase>();

            services.AddScoped<IGetAreasUseCase, GetAreasUseCase>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        string swaggerEndpoint;

                        var basePath = Configuration["ASPNETCORE_BASEPATH"];

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
