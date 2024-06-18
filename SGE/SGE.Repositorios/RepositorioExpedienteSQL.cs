using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class RepositorioExpedienteSQL : IExpedienteRepositorio
{
    //public SGEContext DB = new SGEContext();

    public void AgregarExpedienteAlta(Expediente expediente) 
    {
        using (var DB = new SGEContext())
        { 
            DB.Expedientes.Add(expediente);
            DB.SaveChanges();
        }

    }
    public bool EliminarExpedienteBaja(int id)
    {
        using (var DB = new SGEContext())
        { 

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
    }
    public bool ModificarExpediente(Expediente expediente)
    {
        using (var DB = new SGEContext())
        { 

            var e = DB.Expedientes.Find(expediente.Id);

            if (e != null)
            {
                DB.Expedientes.Remove(e);
                DB.Expedientes.Add(expediente);

                DB.SaveChanges(true);

                return true;
            }

            return false;
        }
    }
    public List<Expediente> ListarExpedientes()
    {
        List<Expediente> lista = new List<Expediente>();

        using (var DB = new SGEContext())
        { 
            foreach (var e in DB.Expedientes)
            {
                lista.Add(e);
            }
        }
        return lista;
    }
    public Expediente? GetExpediente(int id)
    {
        using (var DB = new SGEContext())
        {
            return DB.Expedientes.Find(id);
        }
    }
    public bool ExpedienteConsultarPorId(out Expediente? expediente, int id)
    {
        using (var DB = new SGEContext())
        {
            expediente = DB.Expedientes.Find(id); 
            return expediente != null;
        }
    }
}
