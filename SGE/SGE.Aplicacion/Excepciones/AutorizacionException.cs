namespace SGE.Aplicacion;

public class AutorizacionException(ServicioAutorizacionProvisorio servicio)
{
    public void AutorizarExcepciones(int IdUsuario, Permiso permiso) 
    {
        
        if(!servicio.PoseeElPermiso(IdUsuario, permiso, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
        
    }
}