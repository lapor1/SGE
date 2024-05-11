namespace SGE.Aplicacion;

public static class AutorizacionException
{
    public static bool AutorizarExcepciones(int IdUsuario, out string mensajeError) 
    {
        mensajeError = "";
        if (IdUsuario == 0)
        {
            //throw new Exception(mensajeError);
            mensajeError = "El usuario no cuenta con los permisos adecuados";
        }
        return (mensajeError=="");
    }
}