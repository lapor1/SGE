namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
        {
            tramite.FechaHoraModificacion = DateTime.Now;
            repo.ModificarTramite( tramite );
        }
    }
}