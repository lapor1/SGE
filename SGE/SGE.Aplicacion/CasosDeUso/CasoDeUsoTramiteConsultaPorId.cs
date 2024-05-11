namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultarPorId(ITramiteRepositorio repo, RepositorioException excepcion)
{
    public Tramite? Ejecutar(int id)
    {
        bool encontrado = repo.TramiteConsultarPorId(out Tramite tramite, id);
        try
        {
            excepcion.ConsultarTramite(tramite);
            return tramite;
        }
        catch (Exception ex)
        {
            Console.WriteLine( ex.Message );
        }
        return null;
    }
}