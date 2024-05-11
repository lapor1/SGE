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

                exception.BajaExpediente(encontrado, out string mensajeError);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}