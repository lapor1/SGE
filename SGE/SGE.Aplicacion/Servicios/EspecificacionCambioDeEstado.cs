namespace SGE.Aplicacion;

public class EspecificacionCambioDeEstado 
{
    //mi unico problema es que no se como cambiar el estado, intente haciendo esto pero me sale en rojo
    //si encontras la solucion mejor, pero no se como cambiarlo bien, cree tambien el SetTipoTramite
    //en Tramite.cs, que sirve para cambiar el estado del tramite y poder dejarlo como quiere el enunciado
    //lo mismo hice con los otros 2, por eso hay 3 errores en total.

    //Cuando la etiqueta del último trámite es "Resolución", se produce un cambio automático al estado
    // "Con resolución".
    public void ResolucionConResolucion(Tramite tramite)
    {
        if(tramite.TipoTramite == EtiquetaTramite.Resolucion)
        {
            tramite.SetTipoTramite(EstadoExpediente.ConResolucion);
        }
    }

    //Cuando la etiqueta del último trámite es "Pase a estudio", se produce un cambio automático al
    //estado "Para resolver".

    public void PaseAEstudioParaResolver(Tramite tramite)
    {
        if(tramite.TipoTramite == EtiquetaTramite.PaseAEstudio)
        {
            tramite.SetTipoTramite(EstadoExpediente.ParaResolver);
        }
    }

    //Cuando la etiqueta del último trámite es "Pase al Archivo", se produce un cambio automático al
    //estado "Finalizado".

    public void PaseAlArchivoFinalizado(Tramite tramite)
    {
        if(tramite.TipoTramite == EtiquetaTramite.PaseAlArchivo)
        {
            tramite.SetTipoTramite(EstadoExpediente.Finalizado);
        }
    }
   
}

// [ ]  Además, resultaría beneficioso desacoplar el servicio de la especificación que define qué cambio 
//      de estadodebe llevarse a cabo en función de la etiqueta del último trámite.
//      Esta especificación podría sernsuministrada al servicio mediante la técnica de 
//      inyección de dependencias

