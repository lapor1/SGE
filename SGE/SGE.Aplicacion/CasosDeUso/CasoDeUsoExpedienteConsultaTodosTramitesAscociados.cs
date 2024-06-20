using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteConsultaTodosTramitesAscociados(ITramiteRepositorio repoT)
{
    public List<Tramite> Ejecutar(int idExpediente)
    {
    
        List<Tramite> TramitesAsociados = new List<Tramite>();

        var listarTramites = new CasoDeUsoListarTramites(repoT);
        
        foreach (var trmite in listarTramites.Ejecutar())
        {
            if (trmite.IdExpediente == idExpediente)
            {
                TramitesAsociados.Add(trmite);
            }
        }

        return TramitesAsociados;    
    }
}