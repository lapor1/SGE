namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoT, IServicioAutorizacion autorizacion, RepositorioException excepcion, IExpedienteRepositorio repoE, EspecificacionCambioDeEstado especificacion)
{
    public void Ejecutar(int id, int idUsuario)
    {
        // Obtiene el tramite a eliminar para posteriormente utilizar el expedeinte asociado
        var consTramite = new CasoDeUsoTramiteConsultaPorId(repoT, excepcion);
        Tramite? tramite = consTramite.Ejecutar(id);

        // Verifica si el usuario tiene el permiso necesario para dar de baja un trámite
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            // Elimina el trámite del repositorio y guarda si fue encontrado y eliminado correctamente
            bool encontrado = repoT.EliminarTramiteBaja( id );
            try
            {
                excepcion.BajaTramite(encontrado);

                if(tramite != null){
                    // Modifica el estado del expediente asociado
                    var cambioEsatodoAutomatico = new ServicioActualizarEstado(repoT, repoE, especificacion, autorizacion);
                    cambioEsatodoAutomatico.Ejecutar(tramite.IdExpediente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }
    }
}