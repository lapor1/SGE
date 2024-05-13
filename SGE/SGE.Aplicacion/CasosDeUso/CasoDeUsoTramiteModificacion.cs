namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoT, IServicioAutorizacion autorizacion, RepositorioException excepcion, IExpedienteRepositorio repoE, EspecificacionCambioDeEstado especificacion)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        // Verifica si el usuario tiene el permiso necesario para modificar un trámite
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
        {
            // Actualiza la fecha y hora de modificación del trámite
            tramite.FechaHoraModificacion = DateTime.Now;
            // Asigna el id del usuario que modifica el trámite
            tramite.IdUsuarioUM = idUsuario;
            // Intenta modificar el trámite en el repositorio y guarda si fue encontrado y modificado correctamente
            bool encontrado = repoT.ModificarTramite( tramite );
            
            try
            {
                excepcion.ModificacionTramite( encontrado );

                var cambioEsatodoAutomatico = new ServicioActualizarEstado(repoT, repoE, especificacion, autorizacion);
                cambioEsatodoAutomatico.Ejecutar( tramite.IdTramite );
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }

    }
}