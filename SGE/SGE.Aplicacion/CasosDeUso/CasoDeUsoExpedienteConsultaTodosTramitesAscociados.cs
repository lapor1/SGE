namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodosTramitesAscociados(IExpedienteRepositorio repoE)
{
    public List<Tramite> Ejecutar(int idExpediente)
    {
        /*
        // Obtiene la lista completa de todos los trámites
        List<Tramite> tramitesTotal = repo.ListarTramites();

        // Lista para almacenar los trámites asociados al expediente específico
        List<Tramite> tramitesAsociados = new List<Tramite>();

        // Itera sobre todos los trámites para encontrar los asociados al expediente específico
        foreach (Tramite t in tramitesTotal)
        {
            // Comprueba si el trámite actual está asociado al expediente dado
            if (t.IdExpediente == idExpediente) 
            {
                // Si está asociado, lo agrega a la lista de trámites asociados
                tramitesAsociados.Add(t);
            }
        }
        // Devuelve la lista de trámites asociados al expediente
        return tramitesAsociados;
        */

        Expediente? expediente = repoE.GetExpediente( idExpediente );

        if ( expediente != null )
            //if (expediente.ListaTramites != null)       
                return expediente.ListaTramites;
        return new List<Tramite>(); //lista vacia     
    }
}