namespace SGE.Aplicacion;

public class AutorizacionException
{
    public void AutorizarExcepciones(int IdUsuario) 
    {
        //si el ID del usuario es 0, arroja una excepcion 
        if (IdUsuario == 0)
        {
            throw new Exception("El usuario no cuenta con los permisos adecuados para ejecutar esta accion");
        }
    }
}