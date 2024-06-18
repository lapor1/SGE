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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ------------------ Agregamos servicios (casos de uso, repositorios, servicios)

// Casos De Uso Expedientes
builder.Services.AddTransient<CasoDeUsoListarExpedientes>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();

// Casos De Uso Tramite
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoListarTramites>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();

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

var servicio = new ServicioAutorizacionProvisorio();
var especificacion = new EspecificacionCambioDeEstado();
ITramiteRepositorio repoT = new RepositorioTramiteSQL();
IExpedienteRepositorio repoE = new RepositorioExpedienteSQL();
var validadorTramite = new TramiteValidador();
var validadorExpediente = new ExpedienteValidador();

var altaTramite = new CasoDeUsoTramiteAlta(repoT, servicio, repoE, especificacion, validadorTramite);
var altaExpediente = new CasoDeUsoExpedienteAlta(repoE, servicio, validadorExpediente);
var listExpediente = new CasoDeUsoListarExpedientes(repoE);

    
if (SGESqlite.Inicializar()) {
    //SGESqlite.AgregarUnosTramitesYExpedientes();
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