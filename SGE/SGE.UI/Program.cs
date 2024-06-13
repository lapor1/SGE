using SGE.UI.Components;
using SGE.Aplicacion;
using SGE.Repositorios;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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

app.Run();

/**********************************************************************/

SGESqlite.Inicializar();

using (var context = new SGEContext())
{
    Console.WriteLine("-- Tabla Tramites --");
    foreach (var t in context.Tramites)
    {
        Console.WriteLine($"{t.Id} {t.Contenido}");
    }

    Console.WriteLine("-- Tabla Expedientes --");
    foreach (var ex in context.Expedientes)
    {
        Console.WriteLine($"{ex.Id} {ex.Caratula}");
    }
}

/**********************************************************************/