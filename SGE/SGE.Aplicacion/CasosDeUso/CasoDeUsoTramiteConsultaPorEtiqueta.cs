using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoConsultaPorEtiqueta(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(EtiquetaTramite etiquetaTramite)
    {
        // Obtiene la lista completa de todos los trámites
        List<Tramite> tramitesTotal = repo.ListarTramites();
        // Lista para almacenar los trámites que tienen la etiqueta específica
        List<Tramite> tramitesEtiqueta = new List<Tramite>();
        // Itera sobre todos los trámites para encontrar los que tienen la etiqueta especificada
        foreach (Tramite t in tramitesTotal)
        {
            // Comprueba si el tipo de trámite coincide con la etiqueta proporcionada
            if (t.TipoTramite == etiquetaTramite) 
            {
                // Si coincide, agrega el trámite a la lista de trámites con esa etiqueta
                tramitesEtiqueta.Add(t);
            }
        }
        return tramitesEtiqueta;
        
    }
}