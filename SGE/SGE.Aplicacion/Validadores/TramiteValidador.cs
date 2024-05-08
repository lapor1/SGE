namespace SGE.Aplicacion;

public class TramiteValidador
{
    // [ ]  El contenido de un trámite no puede estar vacío
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            mensajeError = "Contenido vacio";
        }
        return (mensajeError == "");
    }
    
    // [ ]  El id de usuario (en trámites y expedientes) debe ser un id válido (entero mayor que 0)
}
