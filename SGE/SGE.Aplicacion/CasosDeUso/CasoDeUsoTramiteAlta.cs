namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador)
{
    private static int id = 0;  // buscar en el repositorio el id maximo
    public void Ejecutar(Tramite tramite)
    {
        if (!validador.Validar(tramite, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
        id++;
        tramite.IdTramite = id;
        tramite.FechaHoraCreacion = DateTime.Now;
        tramite.FechaHoraModificacion = DateTime.Now;
        tramite.IdUsuarioUM = tramite.IdUsuarioUM == null ? 0 : tramite.IdUsuarioUM;
        repo.AgregarTramiteAlta( tramite );
    }
}