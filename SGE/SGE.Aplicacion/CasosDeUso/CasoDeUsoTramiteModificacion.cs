using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Servicios;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoT, IServicioAutorizacion autorizacion, IExpedienteRepositorio repoE, EspecificacionCambioDeEstado especificacion, TramiteValidador validador)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        // Verifica si el tramite es valido
        if (validador.Validar(tramite, out string mensajeError)) {
        
            // Verifica si el usuario tiene el permiso necesario para modificar un trámite
            if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
            {
                // Actualiza la fecha y hora de modificación del trámite
                tramite.FechaHoraModificacion = DateTime.Now;
                // Asigna el id del usuario que modifica el trámite
                tramite.IdUsuarioUM = idUsuario;

                Expediente? expediente = repoE.GetExpediente( tramite.IdExpediente );

                // Intenta modificar el trámite en el repositorio y guarda si fue encontrado y modificado correctamente
                bool encontrado = repoT.ModificarTramite( tramite );
                
                if (!encontrado){
                    throw new RepositorioException( "El tramite no se puede modificar porque no existe en el repositorio" );
                }
                else{    
                    if ( expediente != null )
                    {
                        expediente.ListaTramites.Remove(tramite.Id);
                        expediente.ListaTramites.Add(tramite.Id);

                        repoE.ModificarExpediente(expediente);

                        var cambioEsatodoAutomatico = new ServicioActualizarEstado(repoE, repoT, especificacion, autorizacion);
                        cambioEsatodoAutomatico.Ejecutar( tramite.IdExpediente );
                    }
                    else
                    {
                        throw new RepositorioException( "no encuentra expediente asociado" );
                    }
                }
            }
            else {
                throw new ValidacionException(mensajeError);
            }
        }

    }
}