using ApiSeguridad.Gateways.DataContext;
using ApiSeguridad.Gateways.Repository;
using AuditSeguridad.Entidades.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiSeguridadContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SecurityService"), options => options.EnableRetryOnFailure()));
builder.Services.AddScoped<IEmpresasRepository, EmpresasRepository>();
builder.Services.AddScoped<IFacultadesRepository, FacultadesRepository>();
builder.Services.AddScoped<IGruposOpcionesRepository, GruposOpcionesRepository>();
builder.Services.AddScoped<IOficinasRepository, OficinasRepository>();
builder.Services.AddScoped<IPerfilesRepository, PerfilesRepository>();
builder.Services.AddScoped<ITransaccionesRepository, TransaccionesRepository>();
builder.Services.AddScoped<ITransaccionFacultadRepository, TransaccionFacultadRepository>();
builder.Services.AddScoped<ITransaccionPerfilRepository, TransaccionPerfilRepository>();
builder.Services.AddScoped<IUsuarioFacultadRepository, UsuarioFacultadRepository>();
builder.Services.AddScoped<IUsuarioOficinaRepository, UsuarioOficinaRepository>();
builder.Services.AddScoped<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o => {
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API - Modulo de Seguridades - Sistema de Auditoria - Romero y Asociados",
        Description = "Net Core API que se encarga del mantenimiento y consulta de las tablas del modulo de Seguridades, asi tambien como para registrar el inicio de sesion de los usuarios"
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
