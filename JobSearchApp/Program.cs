using JobSearchApp.Infrastructure.Data;
using JobSearchApp.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var config = builder.Configuration;
        // Add services to the container using the extension method
        services.ConfigureServices(builder.Configuration);
        services.AddDbContextFactory<ApplicationDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("AzureConnection")));
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var sv = scope.ServiceProvider;
            var context = sv.GetRequiredService<ApplicationDbContext>();
            var logger = sv.GetRequiredService<ILogger<Program>>();
        
            try
            {
                var result = context.TestConnectionAsync().Result;
                logger.LogInformation(result);
                if (args.Contains("revert"))
                {
                    DbInitializer.Revert(context);
                }
                else
                {
                    DbInitializer.Initialize(context);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        app.Run();
    }
}