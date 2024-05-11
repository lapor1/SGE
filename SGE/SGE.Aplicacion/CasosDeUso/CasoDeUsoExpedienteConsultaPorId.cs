namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultarPorId(IExpedienteRepositorio repo, RepositorioException excepcion)
{
    public Expediente? Ejecutar(int id)
    {
        try
        {
            repo.ExpedienteConsultarPorId(out Expediente expediente, id);
            
            excepcion.ConsultarExpediente(expediente);

            return expediente;
        }
        catch (Exception ex)
        {
            Console.WriteLine( ex.Message );
        }
        return null;
    }
}