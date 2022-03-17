using FBTarjeta;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicationDbContext>(options=>
                                                   options.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=TarjetaCredito;Integrated Security=True;"));

builder.Services.AddCors(options =>
                         options.AddPolicy("AlloWebApp",
                         builder => builder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AlloWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
