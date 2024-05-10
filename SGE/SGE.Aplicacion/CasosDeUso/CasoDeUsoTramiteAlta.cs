namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion autorizacion)
{
    private static int id = 0;  // buscar en el repositorio el id maximo
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if (!validador.Validar(tramite, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
        {
            id++;
            tramite.IdTramite = id;
            tramite.FechaHoraCreacion = DateTime.Now;
            tramite.FechaHoraModificacion = DateTime.Now;
            tramite.IdUsuarioUM = tramite.IdUsuarioUM == null ? 0 : tramite.IdUsuarioUM;    // o idUsuario ?
            repo.AgregarTramiteAlta( tramite );
        }
    }
}