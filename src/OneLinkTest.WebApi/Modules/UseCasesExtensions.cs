using Microsoft.Extensions.DependencyInjection;
using OneLinkTest.Application.Services;
using OneLinkTest.Application.UseCases.Areas.GetAreas;
using OneLinkTest.Application.UseCases.Employees.AddEmployee;
using OneLinkTest.Application.UseCases.Employees.GetEmployee;
using OneLinkTest.Application.UseCases.Employees.GetEmployees;
using OneLinkTest.Application.UseCases.Employees.UpdateEmployee;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Domain.Employees;
using OneLinkTest.Infrastructure.DataAccess.Repositories;

namespace OneLinkTest.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notification>();

            services.AddScoped<IAddEmployeeUseCase, AddEmployeeUseCase>();
            services.Decorate<IAddEmployeeUseCase, AddEmployeeValidationUseCase>();

            services.AddScoped<IUpdateEmployeeUseCase, UpdateEmployeeUseCase>();
            services.Decorate<IUpdateEmployeeUseCase, UpdateEmployeeValidationUseCase>();

            services.AddScoped<IGetEmployeesUseCase, GetEmployeesUseCase>();

            services.AddScoped<IGetEmployeeUseCase, GetEmployeeUseCase>();

            services.AddScoped<IGetAreasUseCase, GetAreasUseCase>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();

            return services;
        }
    }
}
