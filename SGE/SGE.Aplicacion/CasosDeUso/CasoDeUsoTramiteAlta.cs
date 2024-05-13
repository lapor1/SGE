namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, IServicioAutorizacion autorizacion, ValidacionException exception)
{
    private static int id = 0;  // buscar en el repositorio el id maximo
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        try
        {
            // Verifica si el trámite es válido
            exception.VerificarTramite(tramite);

            // Verifica si el usuario tiene el permiso necesario para dar de alta un trámite
            if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
            {
                id++;
                // Asigna el nuevo id al trámite
                tramite.IdTramite = id;
                // Establece la fecha y hora de creación del trámite como la fecha y hora actuales
                tramite.FechaHoraCreacion = DateTime.Now;
                // Establece la fecha y hora de modificación del trámite como la fecha y hora actuales
                tramite.FechaHoraModificacion = DateTime.Now;
                // Asigna el id del usuario que realiza la modificación al trámite
                tramite.IdUsuarioUM = idUsuario;
                // Agrega el trámite al repositorio llamando al método AgregarTramiteAlta
                repo.AgregarTramiteAlta( tramite );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}