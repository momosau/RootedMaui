using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using RootedBack.Data;
using RootedBack.Services;
using SharedLibraryy.Services;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Configuration Keys:");
foreach (var key in builder.Configuration.AsEnumerable())
{
    Console.WriteLine($"{key.Key}: {key.Value}");
}
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<RootedDBContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Allow any origin
              .AllowAnyMethod() // Allow any method (GET, POST, etc.)
              .AllowAnyHeader(); // Allow any header
    });
});

builder.Services.AddScoped<IApiServices, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#if !DEBUG
app.UseHttpsRedirection();
#endif
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
