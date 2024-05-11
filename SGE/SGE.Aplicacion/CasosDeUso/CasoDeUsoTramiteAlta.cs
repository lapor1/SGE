namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, IServicioAutorizacion autorizacion, ValidacionException exception)
{
    private static int id = 0;  // buscar en el repositorio el id maximo
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        try
        {
            exception.VerificarTramite(tramite);

            if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
            {
                id++;
                tramite.IdTramite = id;
                tramite.FechaHoraCreacion = DateTime.Now;
                tramite.FechaHoraModificacion = DateTime.Now;
                tramite.IdUsuarioUM = idUsuario;
                repo.AgregarTramiteAlta( tramite );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}