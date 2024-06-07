namespace SGE.Aplicacion;

public class AutorizacionException : Exception  // Notar que ahora hereda de "Exception"
{

    // Ahora :

    public AutorizacionException()
    {
    }

    public AutorizacionException(string? message) : base(message)
    {
    }

    public AutorizacionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }


    // Antes : 
    /*
        public void AutorizarExcepciones(int IdUsuario) 
        {
            //si el ID del usuario es 0, arroja una excepcion 
            if (IdUsuario == 0)
            {
                throw new Exception("El usuario no cuenta con los permisos adecuados para ejecutar esta accion");
            }
    }
    */
}