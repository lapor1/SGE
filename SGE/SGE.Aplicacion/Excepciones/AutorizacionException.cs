namespace SGE.Aplicacion;

public class AutorizacionException
{
    public void AutorizarExcepciones(int IdUsuario) 
    {
        if (IdUsuario == 0)
        {
            throw new Exception("El usuario no cuenta con los permisos adecuados");
        }
    }
}