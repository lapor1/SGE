namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo)
{
    public bool Ejecutar(int id)
    {
        return repo.EliminarTramiteBaja( id );
    }
}