namespace SGE.Aplicacion;

public class ServicioActualizarEstado(ITramiteRepositorio repo, EspecificacionCambioDeEstado especificacion)
{
    public void Ejecutar(int idExpediente)
    {
        Tramite ultumoTramite = new Tramite();
        List<Tramite> tramites= new List<Tramite>();

        var consultarPorId = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repo);
        tramites = consultarPorId.Ejecutar(idExpediente);

        // recuperar etiqueta de SU ultimo tramite
        ultumoTramite = tramites[tramites.Count];

        // realiza cambio estado
        especificacion.ElegirCambio(ultumoTramite.TipoTramite, idExpediente);
    }
}