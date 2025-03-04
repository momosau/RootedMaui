using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using RootedBack.Data;

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


//builder.Services.AddHttpClient<ProductService>();


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
