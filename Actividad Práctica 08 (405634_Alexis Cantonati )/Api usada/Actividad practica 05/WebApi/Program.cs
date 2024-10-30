using Back.Data.Models;
using Back.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<db_turnosContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("DefaultConnection")));

builder.Services.AddScoped < IServicioRepository, ServicioRepository>();

builder.Services.AddScoped<ITurnosRepository, TurnosRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Aplicar la política CORS antes de mapear los controladores
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
