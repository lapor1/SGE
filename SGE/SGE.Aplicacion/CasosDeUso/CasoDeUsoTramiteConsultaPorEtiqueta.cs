namespace SGE.Aplicacion;

public class CasoDeUsoConsultaPorEtiqueta(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(EtiquetaTramite etiquetaTramite)
    {
        List<Tramite> tramitesTotal = repo.ListarTramites();
        List<Tramite> tramitesEtiqueta = new List<Tramite>();
        foreach (Tramite t in tramitesTotal)
        {
            if (t.TipoTramite == etiquetaTramite) 
            {
                tramitesEtiqueta.Add(t);
            }
        }
        return tramitesEtiqueta;
        
    }
}