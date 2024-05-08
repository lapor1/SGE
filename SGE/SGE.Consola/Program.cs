using SGE.Aplicacion;
using SGE.Repositorios;

// Configuracion de dependencias
ITramiteRepositorio repo = new RepositorioTramiteTXT();
//TramiteValidador validador = new TramiteValidador(); //no se si se debe 

Tramite [] tramites = new Tramite[5];

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

tramites[2] = new Tramite() {
    IdExpediente = 2,
    TipoTramite = EtiquetaTramite.ConResolucion,
    Contenido = "ddfg",
    IdUsuarioModificacion = 4,
};

tramites[3] = new Tramite() {
    IdExpediente = 2,
    TipoTramite = EtiquetaTramite.ConResolucion,
    Contenido = "sjshsg",
    IdUsuarioModificacion = 4,
};

tramites[4] = new Tramite() {
    IdExpediente = 2,
    TipoTramite = EtiquetaTramite.ConResolucion,
    Contenido = "sghsgh",
    IdUsuarioModificacion = 4,
};

// Casos de uso
var agregarTramiteAlta = new CasoDeUsoTramiteAlta(repo, new TramiteValidador());

for (int i = 0; i < tramites.Length; i++) {
    try
    {
        agregarTramiteAlta.Ejecutar(tramites[i]);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


var listarTramites = new CasoDeUsoListarTramites(repo);
var lista = listarTramites.Ejecutar();
foreach(Tramite t in lista){
    Console.WriteLine(t);
    Console.WriteLine("\n\n\n");
}

Console.WriteLine("Procede a eliminar el tramite con id = 2\n\n\n");

var eliminarTramiteBaja = new CasoDeUsoTramiteBaja(repo);
eliminarTramiteBaja.Ejecutar(2);

lista = listarTramites.Ejecutar();
foreach(Tramite t in lista){
    Console.WriteLine(t);
    Console.WriteLine("\n\n\n");
}


Console.WriteLine("Procede a modificar el tramite con id = 4\n\n\n");
tramites[4].IdTramite = 5;
tramites[4].Contenido = "nuevo contenido";
tramites[4].TipoTramite = EtiquetaTramite.Finalizado;
tramites[4].IdUsuarioModificacion = 7;

var modificacionTramite = new CasoDeUsoTramiteModificacion(repo);
modificacionTramite.Ejecutar(tramites[4]);

lista = listarTramites.Ejecutar();
foreach(Tramite t in lista){
    Console.WriteLine(t);
    Console.WriteLine("\n\n\n");
}