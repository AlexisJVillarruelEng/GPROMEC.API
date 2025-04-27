using GPROMEC.API.Controllers;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using GPROMEC.DOMAIN.Infrastructure.Data;
using GPROMEC.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");

builder.Services.AddDbContext<GdbContext>(options =>
    options.UseSqlServer(cnx));

// Registrar servicios personalizados
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
builder.Services.AddScoped<IFirmasMatrizIperService, FirmasMatrizIperService>();
builder.Services.AddScoped<IFirmasMatrizIperRepository, FirmasMatrizIperRepository>();
builder.Services.AddScoped<IArchivosGeneradosRepository, ArchivosGeneradosRepository>();
builder.Services.AddScoped<IArchivosGeneradosService, ArchivosGeneradosService>();
builder.Services.AddScoped<IMatrizIpercRepository, MatrizIpercRepository>();
builder.Services.AddScoped<IMatrizIpercService, MatrizIpercService>();
builder.Services.AddScoped<ICabeceraATSRepository, CabeceraATSRepository>();
builder.Services.AddScoped<ICabeceraATSService, CabeceraATSService>();
builder.Services.AddScoped<ICabeceraPermisosRepository, CabeceraPermisosRepository>();
builder.Services.AddScoped<ICabeceraPermisosService, CabeceraPermisosService>();
builder.Services.AddScoped<IDetalleATSRepository, DetalleAtsRepository>();
builder.Services.AddScoped<IDetalleATSService, DetalleAtsService>();
builder.Services.AddScoped<IDetallePermisosGeneralRepository, DetallePermisosGeneralRepository>();
builder.Services.AddScoped<IDetallePermisosGeneralService, DetallePermisoGeneralService>();
builder.Services.AddScoped<IFirmasAtsProcesosRepository, FirmasAtsProcesosRepository>();
builder.Services.AddScoped<IFirmasAtsProcesosService, FirmasAtsProcesosService>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IPermisoService, PermisoService>();
builder.Services.AddScoped<IRespuestaPermisosRepository, RespuestaPermisosRepository>();
builder.Services.AddScoped<IRespuestaPermisosService, RespuestaPermisosService>();
builder.Services.AddScoped<IFormPermisoRepository, FormPermisoRepository>();
builder.Services.AddScoped<IFormPermisoService, FormPermisoService>();

// Add Controllers
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Swagger - SIEMPRE
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseCors();
app.UseAuthorization();
app.MapControllers();

// 🔥 Ahora Swagger estará disponible SIEMPRE
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GP API v1");
    c.RoutePrefix = "swagger"; // UI de Swagger en /swagger
});

// 🔥 Redirigir automáticamente / a /swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.Run();
