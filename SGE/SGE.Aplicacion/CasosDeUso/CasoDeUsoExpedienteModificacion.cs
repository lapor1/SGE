namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente tramite)
    {
        repo.ModificarExpediente( tramite );
    }
}