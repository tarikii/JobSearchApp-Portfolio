using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using JobSearchApp.Infraestructure.Interfaces;
using JobSearchApp.Infraestructure.Repositories;
using JobSearchApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(configuration.GetConnectionString("AzureConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}