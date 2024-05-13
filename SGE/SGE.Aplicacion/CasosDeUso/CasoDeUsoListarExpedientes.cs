namespace SGE.Aplicacion;

public class CasoDeUsoListarExpedientes(IExpedienteRepositorio repo)
{
    public List<Expediente> Ejecutar()
    {
        //devuelve la lista de los Expedientes
        return repo.ListarExpedientes();   
    }
}