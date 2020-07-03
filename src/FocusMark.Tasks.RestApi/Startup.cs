using Amazon;
using Amazon.SimpleNotificationService;
using FocusMark.Tasks.Api.Filters;
using FocusMark.Tasks.Api.Services;
using FocusMark.Tasks.Application;
using FocusMark.Tasks.Application.Services;
using FocusMark.Tasks.Infrastructure;
using FocusMark.Tasks.RestApi;
using FocusMark.Tasks.RestApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FocusMark.Tasks.Api
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
            // FocusMark services
            services.AddFocusMarkAuth(this.Configuration);
            services.AddFocusMarkInfrastructure(this.Configuration);
            services.AddFocusMarkApplication();

            services.AddOptions<SnsConfiguration>("AWS::SNS");
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITaskListService, TaskListSnsService>();
            services.AddScoped<IAmazonSimpleNotificationService, AmazonSimpleNotificationServiceClient>(provider =>
                new AmazonSimpleNotificationServiceClient(RegionEndpoint.USEast1));

            services.AddHttpContextAccessor();
            services.AddControllers(options => options.Filters.Add(new ApiExceptionFilter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
