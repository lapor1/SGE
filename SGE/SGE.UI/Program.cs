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

// ------------------ Agregamos servicios (casos de uso, repositorios, servicios)

// Casos De Uso Expedientes
builder.Services.AddTransient<CasoDeUsoListarExpedientes>();

// Casos De Uso Tramite
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoListarTramites>();

// Casos De Uso Usuarios
builder.Services.AddTransient<CasoDeUsoListarUsuarios>();

// Servicios
builder.Services.AddScoped<TramiteValidador>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionProvisorio>();
builder.Services.AddScoped<EspecificacionCambioDeEstado>();

// Repositorios
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpedienteSQL>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramiteSQL>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuarioSQL>();

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