namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo)
{
    public void Ejecutar(int id)
    {
        repo.EliminarTramiteBaja( id );
    }
}