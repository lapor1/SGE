namespace SGE.Aplicacion;

<<<<<<< HEAD
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
=======
// [ ]  Desarrollar un servicio que, a partir del Id de un expediente, recupere la etiqueta de su último
 //     trámite. Basándose en esta información y conforme a las especificaciones detalladas en este documento,
 //     dicho servicio realizará el cambio de estado del expediente cuando sea necesario. Este servicio podrá ser
 //     invocado por los casos de uso correspondientes después de agregar, modificar o eliminar un trámite.

 
>>>>>>> 9304ad55a65341e975da8f1d57ac68dea62e43af
