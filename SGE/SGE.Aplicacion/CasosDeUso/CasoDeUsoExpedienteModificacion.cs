namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion))
        {
            expediente.FechaHoraModificacion = DateTime.Now;
            repo.ModificarExpediente( expediente );
        }
    }
}