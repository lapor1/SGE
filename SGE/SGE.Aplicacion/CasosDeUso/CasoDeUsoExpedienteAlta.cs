namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
{
    private static int id = 0;  // buscar en el repositorio el id maximo
    public void Ejecutar(Expediente expediente)
    {
        id++;
        expediente.IdExpediente = id;
        expediente.FechaHoraCreacion = DateTime.Now;
        expediente.FechaHoraModificacion = DateTime.Now;
        repo.AgregarExpedienteAlta( expediente );
    }
}