namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpedienteAlta(Expediente expediente);
    void EliminarExpedienteBaja(int id);
    void ModificarExpediente(Expediente expediente);
    List<Expediente> ListarExpedientes();
    Expediente? GetExpediente(int id);
    Expediente obtenerExpedienteDelRepositorio(StreamReader sr);
}
