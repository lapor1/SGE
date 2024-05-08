using SGE.Aplicacion;
using SGE.Repositorios;

// Configuracion de dependencias
ITramiteRepositorio repo = new RepositorioTramiteTXT();

// Casos de uso (creacion)
var agregarTramiteAlta = new CasoDeUsoTramiteAlta(repo);
var listarTramites = new CasoDeUsoListarTramites(repo);

// Casos de uso (ejecucion)
agregarTramiteAlta.Ejecutar(new Tramite() {IdTramite = 1, Contenido = "among us"});
agregarTramiteAlta.Ejecutar(new Tramite() {IdTramite = 2, Contenido = "sus"});

var lista = listarTramites.Ejecutar();
foreach(Tramite t in lista){
    Console.WriteLine(t);
}