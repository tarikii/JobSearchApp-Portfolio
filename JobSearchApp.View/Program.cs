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

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Add services to the container using the extension method

            services.ConfigureServices(builder.Configuration);


            // Configurar DbContext según el proveedor de base de datos seleccionado
            var connectionString = config.GetConnectionString("LocalConnection");
            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
