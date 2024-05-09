namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite tramite)
    {
        tramite.FechaHoraModificacion = DateTime.Now;
        repo.ModificarTramite( tramite );
    }
}