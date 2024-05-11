namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso, out string mensajeError) {

        mensajeError="";
        if (IdUsuario == 1) {
            return true;
        }   

        return false;
        throw new Exception("El usuario no cuenta con los permisos adecuados"); 
    }
}