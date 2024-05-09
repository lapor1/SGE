namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador)
{
    private static int id = 0;
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
        tramite.IdUsuarioModificacion = tramite.IdUsuarioModificacion == null ? 0 : tramite.IdUsuarioModificacion;
        repo.AgregarTramiteAlta( tramite );
    }
}