using JobSearchApp.BusinessLogic.Mapping;
using JobSearchApp.Infrastructure.Data;
using JobSearchApp.Views.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.View
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var config = builder.Configuration;

            // Configuración de servicios
            services.AddDistributedMemoryCache(); // Almacena la sesión en memoria
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Añadir servicios al contenedor
            builder.Services.AddControllersWithViews();
            services.ConfigureServices(builder.Configuration);

            // Configuración de DbContext
            var connectionString = config.GetConnectionString("LocalConnection");
            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            var app = builder.Build();

            // Aplicar migraciones automáticamente
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext();
                try
                {
                    var pendingMigrations = context.Database.GetPendingMigrations();
                    if (pendingMigrations.Any())
                    {
                        context.Database.Migrate();
                        Console.WriteLine("Migraciones aplicadas.");
                    }
                    else
                    {
                        Console.WriteLine("Sin migraciones pendientes.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
                }
            }

            // Configurar el pipeline de solicitud HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Aquí se debe colocar UseSession antes de UseAuthorization
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=HomePage}/{id?}");

            app.Run();
        }
    }
}
