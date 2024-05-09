namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            mensajeError = $"Contenido vacio del traime {tramite.IdTramite}";
        }
        return (mensajeError == "");
    }
}
