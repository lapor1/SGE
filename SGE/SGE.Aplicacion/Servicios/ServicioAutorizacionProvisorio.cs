namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
<<<<<<< HEAD
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso) {
=======
    // [ ]  Este servicio siempre debe responder true cuando el IdUsuario sea igual a 1 y 
    //      false en cualquier otro caso (no hace
    //      falta realizar ninguna verificación)
    public bool Verificacion(int IdUsuario) {
>>>>>>> 9304ad55a65341e975da8f1d57ac68dea62e43af
        if (IdUsuario == 1) {
            return true;
        }
        return false;
    }
}
