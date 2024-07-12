using Microsoft.EntityFrameworkCore;
using Verifarma_Challenge_Backend.Data.UnitOfWork;
using Verifarma_Challenge_Backend.Data;
using Verifarma_Challenge_Backend.Data.Repositories;
using Verifarma_Challenge_Backend.Models;
using Verifarma_Challenge_Backend.Services;


var builder = WebApplication.CreateBuilder(args);

// Configurar Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar ApplicationDbContext
#region Configuracion de BD
// Me traigo la configuración de appsettings.json
var configuration = builder.Configuration;

// Agregar el DbContext al contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
#endregion

// Registrar el Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registrar servicios personalizados
builder.Services.AddScoped<IFarmaciaRepository<Farmacia>, FarmaciaRepository>();
builder.Services.AddScoped<IFarmaciaService, FarmaciaService>();

// Configurar la sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Registrar informacion de politicas CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Policy",
        builder =>
        {
            builder.WithOrigins("http://localhost:7004")
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });

});

var app = builder.Build();

app.UseCors("Policy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
