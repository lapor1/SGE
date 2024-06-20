using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Validadores;

namespace SGE.Aplicacion.Servicios;

public class ServicioActualizarEstado(IExpedienteRepositorio repoE, ITramiteRepositorio repoT, EspecificacionCambioDeEstado especificacion, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idExpediente)
    {

        var excepcion = new RepositorioException();
        var consultarPorIdTramite = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoT);

        List<Tramite> tramites = consultarPorIdTramite.Ejecutar(idExpediente);

        if(tramites.Count > 0)
        {
            Tramite ultumoTramite = tramites[tramites.Count - 1]; // recupera ultimo tramite

            //Verifica que cambio debe hacer segun el tipo de tramite     
            EstadoExpediente? nuevoEstado;
            especificacion.Ejecutar(ultumoTramite.TipoTramite, out nuevoEstado);

            if(nuevoEstado != null)
            {
                //Busca el expedeinte asociado del ultimo tramite
                var consultarPorIdExpediente = new CasoDeUsoExpedienteConsultaPorId(repoE);
                Expediente? expediente = consultarPorIdExpediente.Ejecutar(ultumoTramite.IdExpediente);

                if(expediente != null){
                    // Realiza en cambio
                    var modificacion = new CasoDeUsoExpedienteModificacion(repoE, autorizacion, new ExpedienteValidador());
                    expediente.ExpedienteEstado = (EstadoExpediente) nuevoEstado;
                    modificacion.Ejecutar( (Expediente) expediente, 1);
                    // ¿ El cambio siempre se hace con el usuario 1 ya que tiene permiso ? ¿ o deberia ser el usuario del ultimo tramite ?

                }
            }
        }

    }
}