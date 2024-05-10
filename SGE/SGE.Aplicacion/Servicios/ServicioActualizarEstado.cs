namespace SGE.Aplicacion;

public class ServicioActualizarEstado(EspecificacionCambioDeEstado estado)
{
    public void Agregar(Expediente expediente, Tramite tramite)
    {
        if ( tramite.TipoTramite == EtiquetaTramite.ConResolucion )
        {
            estado.CambiarEstadoConResolucion(expediente);
        }
    }
}