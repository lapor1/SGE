namespace SGE.Aplicacion;

public class EspecificacionCambioDeEstado(IExpedienteRepositorio repo, RepositorioException excepcion, IServicioAutorizacion autorizacion)
{
    public void ActualizarExpediente(int idExpediente, EstadoExpediente nuevoEstado)
    {
        Expediente? expediente = new Expediente();
        var consultarPorId = new CasoDeUsoExpedienteConsultarPorId(repo, excepcion);
        var modificacion = new CasoDeUsoExpedienteModificacion(repo, autorizacion, excepcion);

        expediente = consultarPorId.Ejecutar(idExpediente);
        
        if (expediente != null)
        {
            expediente.ExpedienteEstado = EstadoExpediente.ConResolucion;
            modificacion.Ejecutar(expediente, 1);
        }

    }

    public void ElegirCambio(EtiquetaTramite tipoTramite, int idExpediente)
    {
        if(tipoTramite == EtiquetaTramite.Resolucion)
        {
            ActualizarExpediente(idExpediente, EstadoExpediente.ConResolucion);
        }
        if(tipoTramite == EtiquetaTramite.PaseAEstudio) 
        {
            ActualizarExpediente(idExpediente, EstadoExpediente.ParaResolver);
        }
        if(tipoTramite == EtiquetaTramite.PaseAlArchivo)
        {
            ActualizarExpediente(idExpediente, EstadoExpediente.Finalizado);
        }
    }
}