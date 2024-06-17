using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore.Storage;

namespace SGE.Repositorios;

public class RepositorioTramiteSQL : ITramiteRepositorio
{
    public SGEContext DB = new SGEContext();

    public void AgregarTramiteAlta(Tramite tramite)
    {
        //using var DB = new SGEContext();

        Tramite t = new Tramite();
        
        t.Id = tramite.Id;
        t.Id = tramite.Id;
        t.IdExpediente = tramite.IdExpediente;
        t.TipoTramite = tramite.TipoTramite;
        t.Contenido = tramite.Contenido;
        t.FechaHoraCreacion = tramite.FechaHoraCreacion;
        t.FechaHoraModificacion = tramite.FechaHoraModificacion;
        t.IdUsuarioUM = tramite.IdUsuarioUM;
    
        DB.SaveChanges();
    }

    public bool EliminarTramiteBaja(int id)
    {
        //using var DB = new SGEContext();

        //var t = DB.Tramites.SingleOrDefault(t => t.Id == id);

        var t = DB.Tramites.Find(id);

        if (t != null)
        {
            DB.Tramites.Remove(t);
            DB.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ModificarTramite(Tramite tramite)
    {
        /*
        using var DB = new SGEContext();
        var modi = DB.Tramites.SingleOrDefault(); //MODIFICAR
        if (modi != null)
        {
            foreach (var tr in DB.Tramites)
            {
                Tramite t = new Tramite();
                t.Id = tr.Id;
                t.Id = tr.Id;
                t.IdExpediente = tr.IdExpediente;
                t.TipoTramite = tr.TipoTramite;
                t.Contenido = tr.Contenido;
                t.FechaHoraCreacion = tr.FechaHoraCreacion;
                t.FechaHoraModificacion = tr.FechaHoraModificacion;
                t.IdUsuarioUM = tr.IdUsuarioUM;
            }
            DB.SaveChanges();
            return true;
        }*/

        var t = DB.Tramites.Find(tramite.Id);

        if (t != null)
        {
            DB.Tramites.Remove(t);

            t.Id = tramite.Id;
            t.IdExpediente = tramite.IdExpediente;
            t.TipoTramite = tramite.TipoTramite;
            t.Contenido = tramite.Contenido;
            t.FechaHoraCreacion = tramite.FechaHoraCreacion;
            t.FechaHoraModificacion = tramite.FechaHoraModificacion;
            t.IdUsuarioUM = tramite.IdUsuarioUM;

            DB.Tramites.Add(t);

            DB.SaveChanges(true);

            return true;
        }

        return false;
    }
    public List<Tramite> ListarTramites()
    {
        //using var DB = new SGEContext();

        List<Tramite> lista = new List<Tramite>();
        Tramite t = new Tramite();

        foreach (var tramite in DB.Tramites)
        {
            t.Id = tramite.Id;
            t.Id = tramite.Id;
            t.IdExpediente = tramite.IdExpediente;
            t.TipoTramite = tramite.TipoTramite;
            t.Contenido = tramite.Contenido;
            t.FechaHoraCreacion = tramite.FechaHoraCreacion;
            t.FechaHoraModificacion = tramite.FechaHoraModificacion;
            t.IdUsuarioUM = tramite.IdUsuarioUM;
        
            lista.Add(t);
        }

        return lista;
    }
    
    public bool TramiteConsultarPorId(out Tramite? tramite, int id)
    {
        tramite = DB.Tramites.Find(id); 
        return tramite != null;
    }
}