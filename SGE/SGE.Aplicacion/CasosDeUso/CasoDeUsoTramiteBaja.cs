using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Servicios;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoT, IServicioAutorizacion autorizacion, IExpedienteRepositorio repoE, EspecificacionCambioDeEstado especificacion)
{
    public void Ejecutar(int id, int idUsuario)
    {
        // Obtiene el tramite a eliminar para posteriormente utilizar el expedeinte asociado
        var consTramite = new CasoDeUsoTramiteConsultaPorId(repoT);
        Tramite? tramite = consTramite.Ejecutar(id);

        // Verifica si el usuario tiene el permiso necesario para dar de baja un trámite
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            // Elimina el trámite del repositorio y guarda si fue encontrado y eliminado correctamente
            bool encontrado = repoT.EliminarTramiteBaja( id );

            //excepcion.BajaTramite(encontrado);

            if (!encontrado) {
                throw new RepositorioException("El tramite no se puede eliminar porque no existe en el respositorio");
            }
            else {
                if(tramite != null){
                    // Modifica el estado del expediente asociado
                    var cambioEsatodoAutomatico = new ServicioActualizarEstado(repoE, especificacion, autorizacion);
                    cambioEsatodoAutomatico.Ejecutar(tramite.IdExpediente);

                    Expediente? expediente = repoE.GetExpediente( tramite.IdExpediente );
                    if ( expediente != null ){
                        //if ( expediente.ListaTramites != null )
                            expediente.ListaTramites.Remove(tramite);
                    }
                }
            }
        }
    }
}