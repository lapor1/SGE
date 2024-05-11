namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    /*
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso, out string mensajeError) {

        mensajeError="";
        if (IdUsuario == 1) {
            return true;
        }   

        return false;
        throw new Exception("El usuario no cuenta con los permisos adecuados"); 
    }*/

    public bool PoseeElPermiso(int IdUsuario, Permiso permiso) {

        try
        {
            return AutorizacionException.AutorizarExcepciones(IdUsuario, out string mensajeError);
        }
        catch (Exception ex) 
        {
            Console.WriteLine( ex.Message );
        }
        return false;  
    }
}