using SGE.Aplicacion;
using SGE.Repositorios;

class Programa
{
    //Es el Main el que inicia todo el programa 
    static void Main(string[] args)
    {
        var excepcion = new AutorizacionException();
        var servicio = new ServicioAutorizacionProvisorio(excepcion);
        Console.WriteLine(servicio.PoseeElPermiso(1, Permiso.TramiteBaja) + "\n");
        Console.WriteLine(servicio.PoseeElPermiso(0, Permiso.TramiteBaja) + "\n");

        Tramite tra;
        tra = new Tramite();
        tra.TipoTramite = EtiquetaTramite.Notificacion;
        tra.FechaHoraCreacion = DateTime.Now;
        tra.FechaHoraModificacion = DateTime.Now;
        tra.IdTramite = 1;
        tra.IdExpediente = 1;
        tra.Contenido = null;
        tra.IdUsuarioUM = 1;
        
        Console.WriteLine(tra.ToString()); 

        Console.WriteLine("---------------------------");

        Expediente exp;
        exp = new Expediente();
        exp.IdExpediente = 1;
        exp.Caratula = null;
        exp.FechaHoraCreacion = DateTime.Now;
        exp.FechaHoraModificacion = DateTime.Now;
        exp.IdUsuarioUM = 1;
        exp.ExpedienteEstado = EstadoExpediente.ParaResolver;
        Console.WriteLine(exp.ToString());

        Console.WriteLine("---------------------------");
    }
}
