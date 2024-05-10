namespace SGE.Aplicacion;

public class TramiteValidador
{
    //las validaciones solo validan no dan los mensajes de error
    //eso lo hace las excepciones
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        if (tramite.IdUsuarioUM <= 0) 
        {
            //mensajeError = $"Id de Usuario invalido";
            throw new ValidacionException(mensajeError);
        }
        else if (string.IsNullOrEmpty(tramite.Contenido))
        {
            //mensajeError = $"Contenido vacio del traime {tramite.IdTramite}";
            throw new ValidacionException(mensajeError);
        }
        return (mensajeError == "");
    }
}
