namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion)
{
    private static int id = 0;  // buscar en el repositorio el id maximo
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {
            id++;
            expediente.IdExpediente = id;
            expediente.FechaHoraCreacion = DateTime.Now;
            expediente.FechaHoraModificacion = DateTime.Now;
            repo.AgregarExpedienteAlta( expediente );
        }
    }
}