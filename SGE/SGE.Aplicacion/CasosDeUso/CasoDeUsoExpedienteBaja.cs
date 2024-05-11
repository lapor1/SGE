namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion, RepositorioException exception)
{
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            bool encontrado = repoExpediente.EliminarExpedienteBaja( idExpediente );
            
            try
            {
                exception.BajaExpediente(encontrado);

                var consultarTramitesAsociados = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoTramite);
                List<Tramite> listaTramite = consultarTramitesAsociados.Ejecutar( idExpediente );
                foreach (Tramite tr in listaTramite)
                {
                    repoTramite.EliminarTramiteBaja(tr.IdTramite);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }
    }
}