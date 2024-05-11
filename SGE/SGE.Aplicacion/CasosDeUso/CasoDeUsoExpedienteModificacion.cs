namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion, RepositorioException excepcion)
{
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion))
        {
            expediente.FechaHoraModificacion = DateTime.Now;
            expediente.IdUsuarioUM = idUsuario;
            bool encontrado = repo.ModificarExpediente( expediente );
            
            try
            {
                excepcion.ModificacionExpediente(encontrado);
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }
    }
}