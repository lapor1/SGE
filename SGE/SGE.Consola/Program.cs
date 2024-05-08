using SGE.Aplicacion;
using SGE.Repositorios;

// Configuracion de dependencias
ITramiteRepositorio repo = new RepositorioTramiteTXT();

Tramite [] tramites = new Tramite[2];

tramites[0] = new Tramite() {
    IdExpediente = 1,
    TipoTramite = EtiquetaTramite.ParaResolver,
    Contenido = "contenido tramite 1",
    IdUsuarioModificacion = null,
};

tramites[1] = new Tramite() {
    IdExpediente = 1,
    TipoTramite = EtiquetaTramite.ParaResolver,
    Contenido = "contenido tramite 2",
    IdUsuarioModificacion = 3,
};

// Casos de uso
var agregarTramiteAlta = new CasoDeUsoTramiteAlta(repo);

for (int i = 0; i < tramites.Length; i++) {
    agregarTramiteAlta.Ejecutar(tramites[i]);
}


var listarTramites = new CasoDeUsoListarTramites(repo);
var lista = listarTramites.Ejecutar();
foreach(Tramite t in lista){
    Console.WriteLine(t);
    Console.WriteLine("\n\n\n");
}

var eliminarTramiteBaja = new CasoDeUsoTramiteBaja(repo);
eliminarTramiteBaja.Ejecutar(2);

foreach(Tramite t in lista){
    Console.WriteLine(t);
    Console.WriteLine("\n\n\n");
}