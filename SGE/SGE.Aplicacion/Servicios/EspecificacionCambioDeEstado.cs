namespace SGE.Aplicacion;

public class EspecificacionCambioDeEstado(IExpedienteRepositorio repo)
{

    public void ActualizarExpediente(int idExpediente, EstadoExpediente nuevoEstado)
    {
        Expediente expediente = new Expediente();
        var consultarPorId = new CasoDeUsoExpedienteConsultarPorId(repo);
        var modificacion = new CasoDeUsoExpedienteModificacion(repo);

        expediente = consultarPorId.Ejecutar(idExpediente);
        expediente.estadoExpediente = EstadoExpediente.ConResolucion;
        modificacion.Ejecutar(expediente);
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