namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            repoExpediente.EliminarExpedienteBaja( idExpediente );
            var consultarTramitesAsociados = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoTramite);
            List<Tramite> listaTramite = consultarTramitesAsociados.Ejecutar( idExpediente );
            foreach (Tramite tr in listaTramite)
            {
                repoTramite.EliminarTramiteBaja(tr.IdTramite);
            }
        }
    }
}