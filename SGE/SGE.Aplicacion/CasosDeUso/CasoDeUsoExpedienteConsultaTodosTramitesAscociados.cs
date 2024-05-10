namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodosTramitesAscociados(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(int idExpediente)
    {
        List<Tramite> tramitesTotal = repo.ListarTramites();
        List<Tramite> tramitesAsociados = new List<Tramite>();
        foreach (Tramite t in tramitesTotal)
        {
            if (t.IdExpediente == idExpediente) 
            {
                tramitesAsociados.Add(t);
            }
        }
        return tramitesAsociados;
    }
}