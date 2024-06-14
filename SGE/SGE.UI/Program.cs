using SGE.UI.Components;

// Directivas
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Servicios;
using SGE.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Agregamos servicios (casos de uso)
builder.Services.AddTransient<CasoDeUsoListarExpedientes>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpedienteSQL>();

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


// Como quedarian los repositorios si es una unica BD ??

// 4 tablas : usuarios, tramites, expedientes, permisos

// warnings 

// Donde deberia hacer esto?

/**********************************************************************/
SGESqlite.Inicializar();

using (var context = new SGEContext())
{
    Console.WriteLine("-- Tabla Tramites --");
    foreach (var t in context.Tramites)
    {
        Console.WriteLine($"{t.IdTramite} {t.Contenido}");
    }

    Console.WriteLine("-- Tabla Expedientes --");
    foreach (var ex in context.Expedientes)
    {
        Console.WriteLine($"{ex.IdExpediente} {ex.Caratula}");
    }
}

/**********************************************************************
var listExpediente = new CasoDeUsoListarExpedientes(new RepositorioExpedienteTXT());

Console.WriteLine("\n********** Listado de todos los Expedientes: **********\n");

foreach (Expediente e in listExpediente.Ejecutar()){
    Console.WriteLine(e.ToString());
}
/**********************************************************************/

app.Run();