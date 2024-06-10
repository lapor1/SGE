namespace SGE.Aplicacion;

// Constructor que recibe instancias de repositorios y servicios necesarios
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion)
{
    // Implementación del método Ejecutar que lleva a cabo la lógica para dar de baja un expediente
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        // Verifica si el usuario tiene el permiso necesario para dar de baja un expediente
        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            // Elimina el expediente del repositorio y guarda si fue encontrado y eliminado correctamente
            bool encontrado = repoExpediente.EliminarExpedienteBaja( idExpediente );
            
            //try
            //{
                // Verifica si se encontró y eliminó el expediente correctamente
                //exception.BajaExpediente(encontrado);
                if (!encontrado) {
                    throw new RepositorioException("El Expediente no se puede eliminar porque no existe en el respositorio");
                }
                else {
                    // Crea una instancia del caso de uso CasoDeUsoExpedienteConsultaTodosTramitesAscociados
                    var consultarTramitesAsociados = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoTramite);
                    // Ejecuta el caso de uso para obtener la lista de trámites asociados al expediente
                    List<Tramite> listaTramite = consultarTramitesAsociados.Ejecutar( idExpediente );
                    // Elimina cada trámite asociado al expediente
                    foreach (Tramite tr in listaTramite)
                    {
                        repoTramite.EliminarTramiteBaja(tr.IdTramite);
                    }
                }

            /*
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
            */
        }
    }
}