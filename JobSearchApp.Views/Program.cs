var builder = WebApplication.CreateBuilder(args);

// Configurar servicios de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Aplicar la política de CORS
app.UseCors("AllowAllOrigins");

app.UseRouting();

app.Run();