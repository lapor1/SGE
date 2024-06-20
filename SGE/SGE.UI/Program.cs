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
using SGE.UI.Components.Pages;

using SGE.UI;

using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ------------------ Contenedor de Inyección de Dependencias (casos de uso, repositorios, autentificacion, validacion) ------------------

// Casos De Uso Expedientes
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoListarExpedientes>();

// Casos De Uso Tramite
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoListarTramites>();

// Casos De Uso Usuarios
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaPorEmail>();
builder.Services.AddTransient<CasoDeUsoListarUsuarios>();

// Servicios
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<IServicioHash, ServicioHash>();
builder.Services.AddScoped<TramiteValidador>();
builder.Services.AddScoped<ExpedienteValidador>();
builder.Services.AddScoped<EspecificacionCambioDeEstado>();

// Loggers
builder.Services.AddSingleton<Logger>();

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

    var servicio = new ServicioAutorizacion(new RepositorioUsuarioSQL());
    var especificacion = new EspecificacionCambioDeEstado();
    ITramiteRepositorio repoT = new RepositorioTramiteSQL();
    IExpedienteRepositorio repoE = new RepositorioExpedienteSQL();
    var validadorTramite = new TramiteValidador();
    var validadorExpediente = new ExpedienteValidador();
    var altaTramite = new CasoDeUsoTramiteAlta(repoT, servicio, repoE, especificacion, validadorTramite);
    var altaExpediente = new CasoDeUsoExpedienteAlta(repoE, servicio, validadorExpediente);

    SGESqlite.CrearAdmin();

    Random random = new Random();
    int E = 10;
    int T = 20;
    
    for(int i = 0; i < E; i++) {
        try 
        {
            altaExpediente.Ejecutar(
                new Expediente(){ 
                    Caratula = $"caratula{i}",
                    ExpedienteEstado = (EstadoExpediente) (i % 5),
                },
                1
            );
            Console.WriteLine("Se agrego un expediente");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    for(int i = 0; i < T; i++) {
        try
        {
            altaTramite.Ejecutar(
                new Tramite(){ 
                    IdExpediente = i% E,
                    Contenido = $"contenido{i}",
                    TipoTramite = (EtiquetaTramite) (i % 6),
                    IdUsuarioUM = 1,
                },
                1
            );
            Console.WriteLine("Se agrego un tramite");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

app.Run();