using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Repositorios;

/******************** Instancio los servivios, excepciones, repositorios y casos de uso ***********************/

// Servicios
var servicio = new ServicioAutorizacionProvisorio();

// Especificador de cambio de estado
var especificacion = new EspecificacionCambioDeEstado();

// Repositorios
ITramiteRepositorio repoT = new RepositorioTramiteTXT();
IExpedienteRepositorio repoE = new RepositorioExpedienteTXT();

//Validadores
var validadorTramite = new TramiteValidador();
var validadorExpediente = new ExpedienteValidador();

// Excepciones
//var excepcionVal = new ValidacionException(new TramiteValidador(), new ExpedienteValidador());
//var excepcionRepo = new RepositorioException();

// Casos de uso Tramite
var altaTramite = new CasoDeUsoTramiteAlta(repoT, servicio, repoE, especificacion, validadorTramite);
var bajaTramite = new CasoDeUsoTramiteBaja(repoT, servicio, repoE, especificacion);
var modTramite = new CasoDeUsoTramiteModificacion(repoT, servicio, repoE, especificacion, validadorTramite);
var listTramite = new CasoDeUsoListarTramites(repoT);
var consTramite = new CasoDeUsoTramiteConsultaPorId(repoT);
var consTramitePorEtiqueta = new CasoDeUsoConsultaPorEtiqueta(repoT);

// Casos de uso Expediente
var altaExpediente = new CasoDeUsoExpedienteAlta(repoE, servicio, validadorExpediente);
var bajaExpediente = new CasoDeUsoExpedienteBaja(repoE, repoT, servicio);
var modExpediente = new CasoDeUsoExpedienteModificacion(repoE, servicio, validadorExpediente);
var listExpediente = new CasoDeUsoListarExpedientes(repoE);
var consExpediente = new CasoDeUsoExpedienteConsultaPorId(repoE);
var consExpedienteTramitesAsociados = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoE);

/**************************************************************************************************************

// Pequeño testeo de los permisos de usuario
Console.WriteLine(servicio.PoseeElPermiso(1, Permiso.TramiteBaja) + "\n");
Console.WriteLine(servicio.PoseeElPermiso(0, Permiso.TramiteBaja) + "\n");

/******************************** Doy de alta algunos expedientes *********************************************

Console.WriteLine("Se intentan agregar 4 expedientes al repositorio expediente.txt:\n");

// Expediente con id de usuario invalido
altaExpediente.Ejecutar(
    new Expediente(){ 
        Caratula = "caratula expedietne",
        ExpedienteEstado = EstadoExpediente.ParaResolver
    },
    0 // id usuario
);

// Expediente con caratula vacia
altaExpediente.Ejecutar(
    new Expediente(){
        ExpedienteEstado = EstadoExpediente.EnNotificacion
    },
    1 // id usuario
);

// Expediente Valido
altaExpediente.Ejecutar(
    new Expediente(){
        Caratula = "caratula expedietne",
        ExpedienteEstado = (EstadoExpediente) (new Random().Next() % 5)
    },
    1 // id usuario
);

// Expediente Valido
altaExpediente.Ejecutar(
    new Expediente(){
        Caratula = "caratula expedietne",
        ExpedienteEstado = EstadoExpediente.EnNotificacion
    },
    1 // id usuario
);

/*********************** Hago un listado de todos los Expedientes en el repositorio *************************

Console.WriteLine("\n********** Listado de todos los Expedientes: **********\n");

foreach (Expediente e in listExpediente.Ejecutar()){
    Console.WriteLine(e.ToString());
}

/******************************** Doy de alta algunos tramites *********************************************

Console.WriteLine("Se intentan agregar 5 tramites al repositorio tramite.txt:\n");

// Tramite valido
altaTramite.Ejecutar(
    new Tramite(){
        Contenido = "contenido tramite",
        TipoTramite = EtiquetaTramite.Notificacion,
        IdExpediente = 1   // expediente asociado
    },
    1   // id usuario
);

// Tramite sin Contenido
altaTramite.Ejecutar(
    new Tramite(){
        TipoTramite = EtiquetaTramite.PaseAEstudio,
        IdExpediente = 1   // expediente asociado
    },
    1   // id usuario
);

// Tramite Valido
altaTramite.Ejecutar(
    new Tramite(){
        Contenido = "contenido tramite",
        TipoTramite = (EtiquetaTramite) (new Random().Next() % 6),
        IdExpediente = 2   // expediente asociado
    },
    1   // id usuario
);


// Tramite con IdUsuario invalido
altaTramite.Ejecutar(
    new Tramite(){
        Contenido = "contenido tramite",
        TipoTramite = (EtiquetaTramite) (new Random().Next() % 6),
        IdExpediente = 0   // expediente asociado
    },
    0   // id usuario
);

// Tramite con IdUsuario invalido y sin Contenido
altaTramite.Ejecutar(
    new Tramite(){
        TipoTramite = (EtiquetaTramite) (new Random().Next() % 6),
        IdExpediente = 1   // expediente asociado
    },
    0   // id usuario
);

altaTramite.Ejecutar(
    new Tramite(){
        Contenido = "contenido tramite",
        TipoTramite = EtiquetaTramite.PaseAlArchivo,
        IdExpediente = 3   // expediente asociado
    },
    1   // id usuario
);

/***************************** Hago un listado de todos los Tramites en el repositorio *************************

Console.WriteLine("\n********** Listado de todos los Tramites: **********\n");

foreach (Tramite t in listTramite.Ejecutar()){
    Console.WriteLine(t.ToString());
}

/************************************ Eliminar algunos Tramites *************************************************

Console.WriteLine("Se intentan eliminar tramites dal repositorio tramite.txt:\n");

// Eliminar Tramites 1 y 3 con IdUsuario 1
bajaTramite.Ejecutar(1, 1);
bajaTramite.Ejecutar(3, 1);

// Invalidacion ya que el Tramite 1 ya está eliminado
bajaTramite.Ejecutar(1, 1);

// Invalidacion ya que usuario 0 no tiene permiso
bajaTramite.Ejecutar(2, 0);

/***************************** Eliminar algunos Expedientes (y sus tramites asociados) **************************

Console.WriteLine("Se intentan eliminar Expedientes dal repositorio expediente.txt:\n");

// Eliminar Expedeintes 1 y 3 con IdUsuario 1
bajaExpediente.Ejecutar(1, 1);
bajaExpediente.Ejecutar(3, 1);
// Se borran tambien todos los tramites asociados al expediente 1 y 3

// Invalidacion ya que el Tramite 1 ya está eliminado
bajaExpediente.Ejecutar(1, 1);

// Invalidacion ya que usuario 0 no tiene permiso
bajaExpediente.Ejecutar(2, 0);

/*********************** Hago un listado de todos los Expedientes en el repositorio *****************************

Console.WriteLine("\n********** Listado de todos los Expedientes: **********\n");

foreach (Expediente e in listExpediente.Ejecutar()){
    Console.WriteLine(e.ToString());
}

/***************************** Hago un listado de todos los Tramites en el repositorio ***************************

Console.WriteLine("\n********** Listado de todos los Tramites: **********\n");

foreach (Tramite t in listTramite.Ejecutar()){
    Console.WriteLine(t.ToString());
}

/*************************** Hago una modificacion de algunos Tramites en el repositorio **************************

// Id usuario sin permiso
modTramite.Ejecutar(
    new Tramite(){
        IdTramite = 5, // tramite a modificar
        IdExpediente = 3,
        TipoTramite = EtiquetaTramite.PaseAEstudio,
        Contenido = "sssss"
    },
    0
);

// Consulta y modifica el expediente con id 3 (si lo encuentra)
Tramite? tramiteAux = consTramite.Ejecutar(3);
if (tramiteAux != null) {
    tramiteAux.TipoTramite = EtiquetaTramite.Notificacion;
    modTramite.Ejecutar( (Tramite) tramiteAux, 1);
}

/***************************** Hago un listado de todos los Tramites en el repositorio ***************************

Console.WriteLine("\n********** Listado de todos los Tramites: **********\n");

foreach (Tramite t in listTramite.Ejecutar()){
    Console.WriteLine(t.ToString());
}

/*************************** Hago una modificacion de algunos Expedeintes en el repositorio ************************

// Expediente no encontrado
modExpediente.Ejecutar(
    new Expediente(){
        IdExpediente = 25, // expedeinte a modificar
        ExpedienteEstado = EstadoExpediente.EnNotificacion,
        Caratula = "sssss"
    },
    1
);

//Usuario Invalido
modExpediente.Ejecutar(
    new Expediente(){
        IdExpediente = 5, // expedeinte a modificar
        ExpedienteEstado = EstadoExpediente.EnNotificacion,
        Caratula = "sssss"
    },
    0
);

// Consulta y modifica el expediente con id 2
Expediente? expedienteAux = consExpediente.Ejecutar(2);
if (expedienteAux != null) {
    expedienteAux.Caratula = "hola";
    expedienteAux.ExpedienteEstado = EstadoExpediente.Finalizado;
    modExpediente.Ejecutar( (Expediente) expedienteAux, 1);
}

// Consulta y modifica el expediente con id 1
expedienteAux = consExpediente.Ejecutar(1);
if (expedienteAux != null) {
    expedienteAux.Caratula = "hola";
    modExpediente.Ejecutar( (Expediente) expedienteAux, 1);
}


/*********************** Hago un listado de todos los Expedientes en el repositorio ****************************/

Console.WriteLine("\n********** Listado de todos los Expedientes: **********\n");

foreach (Expediente e in listExpediente.Ejecutar()){
    Console.WriteLine(e.ToString());
}

/******************************** Tramites Asociados un Expedeiente *******************************************

Console.WriteLine("\n********** Todos Los Tramites Asociados al Expedeiente 2: **********\n");

foreach (Tramite t in consExpedienteTramitesAsociados.Ejecutar(2)){
    Console.WriteLine( t.ToString() );
}

Console.WriteLine("\n********** Todos Los Tramites Asociados al Expedeiente 10: **********\n");

foreach (Tramite t in consExpedienteTramitesAsociados.Ejecutar(10)){
    Console.WriteLine( t.ToString() );
}

/******************************** Consulta de Tramites por Etiqueta *******************************************

Console.WriteLine("\n********** Todos Los Tramites con etiqueta 'Notificacion': **********\n");

foreach (Tramite t in consTramitePorEtiqueta.Ejecutar(EtiquetaTramite.Notificacion)){
    Console.WriteLine( t.ToString() );
}

Console.WriteLine("\n********** Todos Los Tramites con etiqueta 'Despachado': **********\n");

foreach (Tramite t in consTramitePorEtiqueta.Ejecutar(EtiquetaTramite.Despachado)){
    Console.WriteLine( t.ToString() );
}

/***************************************************************************************************************

try {

    altaTramite.Ejecutar(
        new Tramite(){
            Contenido = "contenido tramite",
            TipoTramite = EtiquetaTramite.PaseAEstudio,
            IdExpediente = 2   // expediente asociado
        },
        1   // id usuario
    );

}
catch ( Exception e ){
    Console.WriteLine(e.Message);
}

/***************************************************************************************************************


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

*/
