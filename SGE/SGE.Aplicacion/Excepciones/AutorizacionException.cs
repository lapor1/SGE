namespace SGE.Aplicacion;

class AutorizacionException
{
    // [ ]  La excepción AutorizacionException debe ser lanzada cuando un usuario intenta 
    //realizar una operación para la cual no tiene los permisos necesarios.

    //el mensaje lo dice todo, y se aplica siempre que el usuario quiera hacer algo 
    //que no puede por su permiso.
    public AutorizacionException (out string mensajeError) {
        
        mensajeError = $"No posee permiso para realizar esa operacion!";
        
    }
}