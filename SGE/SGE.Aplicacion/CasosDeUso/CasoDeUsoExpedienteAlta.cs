namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente expediente)
    {
        repo.AgregarExpedienteAlta( expediente );
    }
}