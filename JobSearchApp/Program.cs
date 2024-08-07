using JobSearchApp.Infrastructure.Data;
using JobSearchApp.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var config = builder.Configuration;

        // Add services to the container using the extension method
        services.ConfigureServices(builder.Configuration);

        // Configurar DbContext según el proveedor de base de datos seleccionado

        var connectionString = config.GetConnectionString("AzureConnection");
        services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));


        // Log the connection string being used
        var logger = LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger<Program>();
        logger.LogInformation($"Using connection string: {connectionString}");

        services.AddControllers();

        // services.AddDbContextFactory<ApplicationDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("AzureConnection")));
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
        app.Run();
    }
}