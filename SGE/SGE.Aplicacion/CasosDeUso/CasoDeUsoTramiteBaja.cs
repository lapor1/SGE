namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion autorizacion, RepositorioException exception)
{
    public void Ejecutar(int id, int idUsuario)
    {
        // Verifica si el usuario tiene el permiso necesario para dar de baja un trámite
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            // Elimina el trámite del repositorio y guarda si fue encontrado y eliminado correctamente
            bool encontrado = repo.EliminarTramiteBaja( id );
            try
            {
                exception.BajaTramite(encontrado);
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }
    }
}