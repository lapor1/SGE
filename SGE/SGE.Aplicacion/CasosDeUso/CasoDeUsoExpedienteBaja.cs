using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.CasosDeUso;

// Constructor que recibe instancias de repositorios y servicios necesarios
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoE, ITramiteRepositorio repoT, IServicioAutorizacion autorizacion)
{
    // Implementación del método Ejecutar que lleva a cabo la lógica para dar de baja un expediente
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        // Verifica si el usuario tiene el permiso necesario para dar de baja un expediente
        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            // Elimina el expediente del repositorio y guarda si fue encontrado y eliminado correctamente
            bool encontrado = repoE.EliminarExpedienteBaja( idExpediente );
            
            
            // Verifica si se encontró y eliminó el expediente correctamente
            //exception.BajaExpediente(encontrado);
            if (!encontrado) {
                throw new RepositorioException("El Expediente no se puede eliminar porque no existe en el respositorio");
            }
            else {
                // Crea una instancia del caso de uso CasoDeUsoExpedienteConsultaTodosTramitesAscociados
                var consultarTramitesAsociados = new CasoDeUsoExpedienteConsultaTodosTramitesAscociados(repoE);

                // Ejecuta el caso de uso para obtener la lista de trámites asociados al expediente
                List<Tramite> listaTramite = consultarTramitesAsociados.Ejecutar( idExpediente );

                // Elimina cada trámite asociado al expediente
                foreach (Tramite tr in listaTramite)
                {
                    repoT.EliminarTramiteBaja(tr.Id);
                }
            }
        }
    }
}