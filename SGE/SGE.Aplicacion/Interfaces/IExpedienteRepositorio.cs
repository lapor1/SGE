namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpedienteAlta(Expediente expediente);
    bool EliminarExpedienteBaja(int id);
    bool ModificarExpediente(Expediente expediente);
    List<Expediente> ListarExpedientes();
    Expediente? GetExpediente(int id);
    Expediente obtenerExpedienteDelRepositorio(StreamReader sr);
    bool ExpedienteConsultarPorId(out Expediente? expediente, int id);
}
