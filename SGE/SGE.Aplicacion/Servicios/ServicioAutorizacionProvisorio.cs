namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio
{
    // [ ]  Este servicio siempre debe responder true cuando el IdUsuario sea igual a 1 y false en cualquier otro caso (no hace
    //      falta realizar ninguna verificación)
    public bool Verificacion(int IdUsuario) {
        if (IdUsuario == 1) {
            return true;
        }
        return false;
    }
}
