namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, IServicioAutorizacion autorizacion, RepositorioException excepcion)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion, out string mensajeError))
        {
            tramite.FechaHoraModificacion = DateTime.Now;
            tramite.IdUsuarioUM = idUsuario;
            
            bool encontrado = repo.ModificarTramite( tramite );
            
            try
            {
                excepcion.ModificacionTramite( encontrado );
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }

    }
}