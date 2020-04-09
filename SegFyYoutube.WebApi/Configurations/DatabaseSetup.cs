using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SegFyYoutube.Infra.Context;
using System;

namespace SegFyYoutube.WebApi.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SegFyContext>(options =>
                options.UseMySql(configuration.GetConnectionString("teste")));
        }
    }
}
