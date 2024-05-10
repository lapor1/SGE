namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        if (tramite.IdUsuarioUM <= 0) 
        {
            throw new ValidacionException("Id de Usuario inválido");
        }
        else if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new ValidacionException($"Contenido vacío del trámite {tramite.IdTramite}");
        }
        return (mensajeError == "");
    }
}
