namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            repoExpediente.EliminarExpedienteBaja( idExpediente );
            List<Tramite> listaTramite = repoTramite.TramiteConsultarListaConIdExpediente( idExpediente );
            foreach (Tramite tr in listaTramite)
            {
                repoTramite.EliminarTramiteBaja(tr.IdTramite);
            }
        }
    }
}