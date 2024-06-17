using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class RepositorioExpedienteSQL : IExpedienteRepositorio
{
    public SGEContext DB = new SGEContext();

    public void AgregarExpedienteAlta(Expediente expediente) 
    {
        //using var context = new SGEContext();

        Expediente e = new Expediente();
        
        e.Id = expediente.Id;
        e.Caratula = expediente.Caratula;
        e.FechaHoraCreacion = expediente.FechaHoraCreacion;
        e.FechaHoraModificacion = expediente.FechaHoraModificacion;
        e.IdUsuarioUM = expediente.IdUsuarioUM;
        e.ExpedienteEstado = expediente.ExpedienteEstado;
        

        DB.Expedientes.Add(e);
        DB.SaveChanges();

    }
    public bool EliminarExpedienteBaja(int id)
    {
        //using var context = new SGEContext();

        //var exp = context.Expedientes.SingleOrDefault(e => e.Id == id);

        var e = DB.Expedientes.Find(id);

        if (e != null)
        {
            DB.Expedientes.Remove(e);
            DB.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ModificarExpediente(Expediente expediente)
    {
        /*
        using var context = new SGEContext();

        var modi = context.Expedientes.SingleOrDefault(); //MODIFICAR

        if (modi != null)
        {
            foreach (var ex in context.Expedientes)
            {
                Expediente e = new Expediente();
                e.Id = ex.Id;
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
            */

        var e = DB.Expedientes.Find(expediente.Id);

        if (e != null)
        {
            DB.Expedientes.Remove(e);

            e.Id = expediente.Id;
            e.Caratula = expediente.Caratula;
            e.FechaHoraCreacion = expediente.FechaHoraCreacion;
            e.FechaHoraModificacion = expediente.FechaHoraModificacion;
            e.IdUsuarioUM = expediente.IdUsuarioUM;
            e.ExpedienteEstado = expediente.ExpedienteEstado;

            DB.Expedientes.Add(e);

            DB.SaveChanges(true);

            return true;
        }

        return false;
        
    }
    public List<Expediente> ListarExpedientes()
    {
        //using var context = new SGEContext();

        List<Expediente> lista = new List<Expediente>();
        Expediente e = new Expediente();

        foreach (var ex in DB.Expedientes)
        {
            e.Id = ex.Id;
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
        return DB.Expedientes.Find(id);
    }
    public bool ExpedienteConsultarPorId(out Expediente? expediente, int id)
    {
        expediente = DB.Expedientes.Find(id); 
        return expediente != null;
    }
}
