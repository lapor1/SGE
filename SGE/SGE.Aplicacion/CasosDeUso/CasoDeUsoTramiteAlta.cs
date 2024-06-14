using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoT, IServicioAutorizacion autorizacion, IExpedienteRepositorio repoE, EspecificacionCambioDeEstado especificacion, TramiteValidador validador)
{
    private static int id = 0;  // buscar en el repositorio el id maximo

    private void IniciarId()
    {
        var listTramite = new CasoDeUsoListarTramites(repoT);
        List<Tramite> tramites = listTramite.Ejecutar();
        if (tramites.Count > 0){
            id = tramites[tramites.Count - 1].IdTramite + 1;
        }
    }

    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        tramite.IdUsuarioUM = idUsuario; // Asigna el id del usuario que realiza la modificación al trámite

        // Verifica si el trámite es válido
        if (validador.Validar(tramite, out string mensajeError))
        {
            // Verifica si el usuario tiene el permiso necesario para dar de alta un trámite
            if (autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
            {
                if (id == 0){
                    IniciarId();   //lee del repositorio cual es el ultimo IdTramte para que no se sobre-escriba
                } else {
                    id++;   //incrementa el Id del expediente
                }
                tramite.IdTramite = id; // Asigna el nuevo id al trámite
                
                tramite.FechaHoraCreacion = DateTime.Now;  // Establece la fecha y hora de creación del trámite como la fecha y hora actuales
                tramite.FechaHoraModificacion = DateTime.Now; // Establece la fecha y hora de modificación del trámite como la fecha y hora actuales

                var cambioEsatodoAutomatico = new ServicioActualizarEstado(repoE, especificacion, autorizacion);
                cambioEsatodoAutomatico.Ejecutar(tramite.IdExpediente);

                repoT.AgregarTramiteAlta( tramite ); // Agrega el trámite al repositorio llamando al método AgregarTramiteAlta

                Expediente? expediente = repoE.GetExpediente( tramite.IdExpediente );
                if ( expediente != null ){
                    //if ( expediente.ListaTramites != null )
                        expediente.ListaTramites.Add(tramite);
                }
                else {
                    //throw new Exception( "No existe expediente" );
                }
            }
            else
            {
                throw new AutorizacionException("El usuario no cuenta con los permisos adecuados para ejecutar esta accion");
            }
        }
        else
        {
            //excepcion.VerificarTramite(tramite);
            throw new ValidacionException(mensajeError);
        }
    }
}