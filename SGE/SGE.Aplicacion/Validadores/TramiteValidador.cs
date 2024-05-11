namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        if (tramite.IdUsuarioUM <= 0) 
        {
            throw new Exception("Id de Usuario inválido");
        }
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new Exception("El contenido esta vacio!");
        }
        return (mensajeError == "");
    }
}
