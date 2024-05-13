using SGE.Aplicacion;
using SGE.Repositorios;

/******************** Instancio los servivios, excepciones, repositorios y casos de uso ***********************/

// Servicios
var servicio = new ServicioAutorizacionProvisorio(new AutorizacionException());

// Repositorios
ITramiteRepositorio repoT = new RepositorioTramiteTXT();
IExpedienteRepositorio repoE = new RepositorioExpedienteTXT();

// Excepciones
var excepcionVal = new ValidacionException(new TramiteValidador(), new ExpedienteValidador());
var excepcionRepo = new RepositorioException();

// Casos de uso Tramite
var altaTramite = new CasoDeUsoTramiteAlta(repoT, servicio, excepcionVal);
var bajaTramite = new CasoDeUsoTramiteBaja(repoT, servicio, excepcionRepo);
var modTramite = new CasoDeUsoTramiteModificacion(repoT, servicio, excepcionRepo);
var listTramite = new CasoDeUsoListarTramites(repoT);
var consTramite = new CasoDeUsoTramiteConsultaPorId(repoT, excepcionRepo);
var consTramitePorEtiqueta = new CasoDeUsoConsultaPorEtiqueta(repoT);

// Casos de uso Expediente
var altaExpediente = new CasoDeUsoExpedienteAlta(repoE, servicio, excepcionVal);
var bajaExpediente = new CasoDeUsoExpedienteBaja(repoE, repoT, servicio, excepcionRepo);
var modExpediente = new CasoDeUsoExpedienteModificacion(repoE, servicio, excepcionRepo);
var listExpediente = new CasoDeUsoListarExpedientes(repoE);
var consExpediente = new CasoDeUsoExpedienteConsultaPorId(repoE, excepcionRepo);
var consExpedienteTramitesAsociados = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoT);

/**************************************************************************************************************

Console.WriteLine(servicio.PoseeElPermiso(1, Permiso.TramiteBaja) + "\n");
Console.WriteLine(servicio.PoseeElPermiso(0, Permiso.TramiteBaja) + "\n");

/******************************** Doy de alta algunos expedientes *********************************************/

Console.WriteLine("Se intentan agregar 3 expedientes al repositorio expediente.txt:\n");

altaExpediente.Ejecutar(
    new Expediente(){ 
        Caratula = "caratula expedietne",
        ExpedienteEstado = EstadoExpediente.ParaResolver
    },
    0 // id usuario
);

altaExpediente.Ejecutar(
    new Expediente(){
        ExpedienteEstado = EstadoExpediente.EnNotificacion
    },
    1 // id usuario
);

altaExpediente.Ejecutar(
    new Expediente(){
        Caratula = "caratula expedietne",
        ExpedienteEstado = EstadoExpediente.EnNotificacion
    },
    1 // id usuario
);

// Hago un listado de todos los expedientes en el repositorio (junto con los recien agregados si es que cumplen con las validaciones)

Console.WriteLine("\n********** Listado de todos los Expedientes: **********\n");

List<Expediente> expedientes = listExpediente.Ejecutar();

foreach (Expediente e in expedientes){
    Console.WriteLine(e.ToString());
}

/******************************** Doy de alta algunos tramites *********************************************/

Console.WriteLine("Se intentan agregar 3 tramites al repositorio tramite.txt:\n");

altaTramite.Ejecutar(
    new Tramite(){
        Contenido = "contenido tramite",
        TipoTramite = EtiquetaTramite.EscritoPresentado,
        IdExpediente = 1,   // expediente asociado
    },
    1   // id usuario
);

altaTramite.Ejecutar(
    new Tramite(){
        TipoTramite = EtiquetaTramite.PaseAEstudio,
        IdExpediente = 1,   // expediente asociado
    },
    1   // id usuario
);

altaTramite.Ejecutar(
    new Tramite(){
        Contenido = "contenido tramite",
        TipoTramite = (EtiquetaTramite) (new Random().Next() % 5),
        IdExpediente = 1,   // expediente asociado
    },
    1   // id usuario
);

// Hago un listado de todos los tramites en el repositorio (junto con los recien agregados si es que cumplen con las validaciones)

Console.WriteLine("\n********** Listado de todos los Tramites: **********\n");

List<Tramite> tramites = listTramite.Ejecutar();

foreach (Tramite t in tramites){
    Console.WriteLine(t.ToString());
}

/**************************************************************************************************************/