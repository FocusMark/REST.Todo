using FocusMark.Tasks.Application;
using FocusMark.Tasks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FocusMark.Tasks.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFocusMarkInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<TasksDbContext>(options => options.UseInMemoryDatabase("TasksDb"));
            }

            services.AddScoped<TasksDbContext>();
            services.AddScoped<ITasksDbContext>(provider => provider.GetService<TasksDbContext>()); 
            services.AddHealthChecks()
                 .AddDbContextCheck<TasksDbContext>();

            return services;
        }
    }
}
