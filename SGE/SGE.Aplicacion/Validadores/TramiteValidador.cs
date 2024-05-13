namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        //valida si el usuario es valido 
        if (tramite.IdUsuarioUM <= 0) 
        {
            throw new Exception("Id de Usuario inválido");
        }
        //valida si el contenido del expediente no esta vacio
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new Exception("El contenido esta vacio!");
        }
        return (mensajeError == "");
    }
}
