namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente expediente)
    {
        expediente.FechaHoraModificacion = DateTime.Now;
        repo.ModificarExpediente( expediente );
    }
}