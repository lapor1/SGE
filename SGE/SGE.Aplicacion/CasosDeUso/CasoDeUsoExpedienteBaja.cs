namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo)
{
    public void Ejecutar(int id)
    {
        repo.EliminarExpedienteBaja( id );
    }
}