using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class RepositorioExpedienteSQL : IExpedienteRepositorio
{
    public void AgregarExpedienteAlta(Expediente expediente) 
    {
        using var context = new SGEContext();

        Expediente n = new Expediente();
        {
            n.Id = expediente.Id;
            n.IdExpediente = expediente.IdExpediente;
            n.Caratula = expediente.Caratula;
            n.FechaHoraCreacion = expediente.FechaHoraCreacion;
            n.FechaHoraModificacion = expediente.FechaHoraModificacion;
            n.IdUsuarioUM = expediente.IdUsuarioUM;
            n.ExpedienteEstado = expediente.ExpedienteEstado;
        }

        context.Add(n);
        context.SaveChanges();

    }
    public bool EliminarExpedienteBaja(int id)
    {
        using var context = new SGEContext();

        var exp = context.Expedientes.SingleOrDefault(e => e.Id == id);

        if (exp != null)
        {
            context.Expedientes.Remove(exp);
            context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ModificarExpediente(Expediente expediente)
    {
        using var context = new SGEContext();

        var modi = context.Expedientes.SingleOrDefault(); //MODIFICAR

        if (modi != null)
        {
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
            }

            context.SaveChanges();
            return true;
        }
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
