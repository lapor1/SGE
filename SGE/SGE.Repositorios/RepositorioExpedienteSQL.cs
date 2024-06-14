using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Repositorios;

public class RepositorioExpedienteSQL : IExpedienteRepositorio
{
    public void AgregarExpedienteAlta(Expediente expediente) 
    {
        using var context = new SGEContext();

    }
    public bool EliminarExpedienteBaja(int id)
    {
        return false;
    }
    public bool ModificarExpediente(Expediente expediente)
    {
        return false;
    }
    public List<Expediente> ListarExpedientes()
    {
        using var context = new SGEContext();

        List<Expediente> lista = new List<Expediente>();

        foreach (var ex in context.Expedientes)
        {
            Expediente e = new Expediente();
            e.Id = ex.Id;
            e.IdExpediente = ex.IdExpediente;
            e.Caratula = ex.Caratula;
            e.FechaHoraCreacion = ex.FechaHoraCreacion;
            e.FechaHoraModificacion = ex.FechaHoraModificacion;
            e.IdUsuarioUM = ex.IdUsuarioUM;
            e.ExpedienteEstado = ex.ExpedienteEstado;
            
            lista.Add(e);
        }

        return lista;
    }
    public Expediente? GetExpediente(int id)
    {
        return null;
    }
    public Expediente obtenerExpedienteDelRepositorio(StreamReader sr)
    {
        return new Expediente();
    }
    public bool ExpedienteConsultarPorId(out Expediente? expediente, int id)
    {
        expediente = null;
        return false;
    }
}
