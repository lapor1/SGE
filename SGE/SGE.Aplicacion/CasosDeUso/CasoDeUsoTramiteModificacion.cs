namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite tramite)
    {
        repo.ModificarTramite( tramite );
    }
}