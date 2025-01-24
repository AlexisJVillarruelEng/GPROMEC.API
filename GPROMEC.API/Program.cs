using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using GPROMEC.DOMAIN.Infrastructure.Data;
using GPROMEC.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<GdbContext>
    (options => options.UseSqlServer(cnx));

// Registrar servicios personalizados (Ejemplo)
builder.Services.AddScoped<IUbigeoRepository, UbigeoRepository>();
builder.Services.AddScoped<IUbigeoService, UbigeoService>();

builder.Services.AddScoped<ITareasRepository, TareasRepository>();
builder.Services.AddScoped<ITareasService, TareasService>();

builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRolesService, RolesService>();

builder.Services.AddScoped<IProcesosRepository, ProcesosRepository>();
builder.Services.AddScoped<IProcesosService, ProcesosService>();

builder.Services.AddScoped<IPartidasRepository, PartidasRepository>();
builder.Services.AddScoped<IPartidasService, PartidasService>();

builder.Services.AddScoped<IObrasRepository, ObrasRepository>();
builder.Services.AddScoped<IObrasService, ObrasService>();


builder.Services.AddScoped<IProyectosService, ProyectosService>();
builder.Services.AddScoped<IProyectosRepository, ProyectosRepository>();

builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

builder.Services.AddScoped<IDetalleIpercService, DetalleIpercService>();
builder.Services.AddScoped<IDetalleIpercRepository, DetalleIpercRepository>();

builder.Services.AddScoped<ITrabajadoresService, TrabajadoresService>();
builder.Services.AddScoped<ITrabajadoresRepository, TrabajadoresRepository>();

// Agrega todos los servicios e interfaces que uses.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
