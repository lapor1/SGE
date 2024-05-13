namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultarPorId(IExpedienteRepositorio repo, RepositorioException excepcion)
{
    public Expediente? Ejecutar(int id)
    {
        try
        {
            // Llama al método del repositorio para consultar un expediente por su id
            repo.ExpedienteConsultarPorId(out Expediente expediente, id);
            // Verifica si el expediente consultado es válido
            excepcion.ConsultarExpediente(expediente);
            // Devuelve el expediente consultado
            return expediente;
        }
        catch (Exception ex)
        {
            Console.WriteLine( ex.Message );
        }
        // Si hay algún error, devuelve null
        return null;
    }
}