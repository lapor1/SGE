using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Servicios;

public class EspecificacionCambioDeEstado
{
    public void Ejecutar(EtiquetaTramite tipoTramite, out EstadoExpediente? nuevoEstado)
    {
        nuevoEstado = null;
        if(tipoTramite == EtiquetaTramite.Resolucion)
        {
           nuevoEstado = EstadoExpediente.ConResolucion;
        }
        if(tipoTramite == EtiquetaTramite.PaseAEstudio) 
        {
            nuevoEstado = EstadoExpediente.ParaResolver;
        }
        if(tipoTramite == EtiquetaTramite.PaseAlArchivo)
        {
            nuevoEstado = EstadoExpediente.Finalizado;
        }
    }
}