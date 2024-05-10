namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            repo.EliminarTramiteBaja( id );
        }
    }
}