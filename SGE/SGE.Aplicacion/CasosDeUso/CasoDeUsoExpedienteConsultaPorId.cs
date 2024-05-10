namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultarPorId(IExpedienteRepositorio repo)
{
    public Expediente Ejecutar(int id)
    {
        Expediente expediente= new Expediente();
        repo.ExpedienteConsultarPorId(out expediente, id);
        return expediente;
    }
/*  Esta es otra implementacion por si se considera que no encuentra el expediente
    public Expediente? Ejecutar(int id)
    {
        Expediente expediente= new Expediente();
        if(repo.ExpedienteConsultarPorId(out expediente, id))
        {
            return expediente;
        }
        return null;
    }*/
}