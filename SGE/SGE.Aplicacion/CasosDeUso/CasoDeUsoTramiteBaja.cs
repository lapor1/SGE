namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion autorizacion, RepositorioException exception)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
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