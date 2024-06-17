using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteConsultaTodosTramitesAscociados(IExpedienteRepositorio repoE)
{
    public List<Tramite> Ejecutar(int idExpediente)
    {
        Expediente? expediente = repoE.GetExpediente( idExpediente );

        if ( expediente != null )
            //if (expediente.ListaTramites != null)       
                return expediente.ListaTramites;
        return new List<Tramite>(); //lista vacia     
    }
}