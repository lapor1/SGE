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
/*
        var excepcion = new RepositorioException();
        var consultarPorIdTramite = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoT);

        List<Tramite> tramitesAsociados = consultarPorIdTramite.Ejecutar(idExpediente);

        if(tramitesAsociados.Count > 0)
        {
            Tramite ultimoTramite = tramitesAsociados[0]; // recupera ultimo tramite agrgago (el ultimo de la lista)

            foreach (Tramite tAux in tramitesAsociados)
            {
                if(tAux.FechaHoraModificacion > ultimoTramite.FechaHoraModificacion)
                {
                    ultimoTramite = tAux;
                }
            }
*/
        var consultarPorIdExpediente = new CasoDeUsoExpedienteConsultaPorId(repoE);
        Expediente? expediente = consultarPorIdExpediente.Ejecutar(idExpediente);
        
        if(expediente != null){

            var consultarPorIdTramite = new CasoDeUsoTramiteConsultaPorId(repoT);

            if(expediente.ListaTramites.Count > 0){

                Tramite? ultimoTramite = consultarPorIdTramite.Ejecutar(expediente.ListaTramites[expediente.ListaTramites.Count - 1]);

                if(ultimoTramite != null){

                    //Verifica que cambio debe hacer segun el tipo de tramite     
                    EstadoExpediente? nuevoEstado;
                    especificacion.Ejecutar(ultimoTramite.TipoTramite, out nuevoEstado);

                    if(nuevoEstado != null)
                    {   

                        // Realiza en cambio
                        var modificacion = new CasoDeUsoExpedienteModificacion(repoE, autorizacion, new ExpedienteValidador());
                        expediente.ExpedienteEstado = (EstadoExpediente) nuevoEstado;
                        modificacion.Ejecutar( (Expediente) expediente, 1);
                    }
                }
            }

        }

        //}

    }
}