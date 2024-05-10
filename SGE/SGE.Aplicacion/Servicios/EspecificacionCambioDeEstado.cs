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

    //Cuando la etiqueta del último trámite es "Resolución", se produce un cambio automático al estado
    // "Con resolución".
    public void ResolucionConResolucion(Tramite tramite)
    {
        if(tramite.TipoTramite == EtiquetaTramite.Resolucion)
        {
            ActualizarExpediente(tramite.IdExpediente, EstadoExpediente.ConResolucion);
        }
    }

    //Cuando la etiqueta del último trámite es "Pase a estudio", se produce un cambio automático al
    //estado "Para resolver".
    public void PaseAEstudioParaResolver(Tramite tramite)
    {
        if(tramite.TipoTramite == EtiquetaTramite.PaseAEstudio) 
        {
            ActualizarExpediente(tramite.IdExpediente, EstadoExpediente.ParaResolver);
        }
    }

    //Cuando la etiqueta del último trámite es "Pase al Archivo", se produce un cambio automático al
    //estado "Finalizado".
    public void PaseAlArchivoFinalizado(Tramite tramite)
    {
        if(tramite.TipoTramite == EtiquetaTramite.PaseAlArchivo)
        {
            ActualizarExpediente(tramite.IdExpediente, EstadoExpediente.Finalizado);
        }
    }
   
}