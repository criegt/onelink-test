using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneLinkTest.Infrastructure.DataAccess;

namespace OneLinkTest.WebApi.Modules
{
    public static class SqlServerExtensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OneLinkTestContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("OneLinkTest")));
            return services;
        }
    }
}
