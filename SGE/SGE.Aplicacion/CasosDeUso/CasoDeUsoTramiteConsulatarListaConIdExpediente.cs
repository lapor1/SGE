namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsulatarListaConIdExpediente(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(int idExpediente)
    {
        return repo.TramiteConsultarListaConIdExpediente(idExpediente);
    }
}