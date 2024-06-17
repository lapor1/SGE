using SGE.UI.Components;

// Directivas de Aplicacion
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Servicios;

// Directivas de Repositorio
using SGE.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Agregamos servicios (casos de uso, repositorios, servicios)
builder.Services.AddTransient<CasoDeUsoListarExpedientes>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpedienteSQL>();

builder.Services.AddTransient<CasoDeUsoListarTramites>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();

builder.Services.AddScoped<EspecificacionCambioDeEstado>();
builder.Services.AddScoped<TramiteValidador>();

builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionProvisorio>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramiteSQL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

if (SGESqlite.Inicializar()) {
    SGESqlite.AgregarUnosTramitesYExpedientes();
    SGESqlite.CrearAdmin();
}

app.Run();