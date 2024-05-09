namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        if (tramite.IdUsuarioModificacion <= 0) 
        {
            mensajeError = $"Id de Usuario invalido";
        }
        else if (string.IsNullOrEmpty(tramite.Contenido))
        {
            mensajeError = $"Contenido vacio del traime {tramite.IdTramite}";
        }
        return (mensajeError == "");
    }
}
