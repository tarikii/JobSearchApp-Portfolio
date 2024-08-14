using Microsoft.EntityFrameworkCore;
using Swipe4Work.Infrastructure.Data;

namespace Swipe4Work
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var config = builder.Configuration;

            // Añade los servicios necesarios para los controladores y vistas
            services.AddControllersWithViews();

            // Configurar DbContext según el proveedor de base de datos seleccionado
            var connectionString = config.GetConnectionString("LocalConnection");
            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Log the connection string being used
            var logger = LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger<Program>();
            logger.LogInformation($"Using connection string: {connectionString}");

            Swipe4Work.DataAccessLayer.DependencyInjection.Configure(builder.Services);
            Swipe4Work.BusinessLogic.DependencyInjection.Configure(builder.Services);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=HomePage}/{id?}");

            app.Run();
        }
    }
}
