namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
        {
            tramite.FechaHoraModificacion = DateTime.Now;
            tramite.IdUsuarioUM = idUsuario;
            repo.ModificarTramite( tramite );
        }
    }
}