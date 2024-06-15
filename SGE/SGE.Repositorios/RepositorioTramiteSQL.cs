using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Repositorios;

public class RepositorioTramiteSQL : ITramiteRepositorio
{
    public void AgregarTramiteAlta(Tramite tramite)
    {
        using var context = new SGEContext();

        Tramite n = new Tramite();
        {
            n.Id = tramite.Id;
            n.IdTramite = tramite.IdTramite;
            n.IdExpediente = tramite.IdExpediente;
            n.TipoTramite = tramite.TipoTramite;
            n.Contenido = tramite.Contenido;
            n.FechaHoraCreacion = tramite.FechaHoraCreacion;
            n.FechaHoraModificacion = tramite.FechaHoraModificacion;
            n.IdUsuarioUM = tramite.IdUsuarioUM;
        }

        context.Add(n);
        context.SaveChanges();
    }

    public bool EliminarTramiteBaja(int id)
    {
       using var context = new SGEContext();

        var tra = context.Tramites.SingleOrDefault(e => e.Id == id);

        if (tra != null)
        {
            context.Tramites.Remove(tra);
            context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ModificarTramite(Tramite tramite)
    {
        using var context = new SGEContext();

        var modi = context.Tramites.SingleOrDefault(); //MODIFICAR

        if (modi != null)
        {
            foreach (var tr in context.Tramites)
            {
            Tramite t = new Tramite();
            t.Id = tr.Id;
            t.IdTramite = tr.IdTramite;
            t.IdExpediente = tr.IdExpediente;
            t.TipoTramite = tr.TipoTramite;
            t.Contenido = tr.Contenido;
            t.FechaHoraCreacion = tr.FechaHoraCreacion;
            t.FechaHoraModificacion = tr.FechaHoraModificacion;
            t.IdUsuarioUM = tr.IdUsuarioUM;
            }

            context.SaveChanges();
            return true;
        }

        return false;
    }
    public List<Tramite> ListarTramites()
    {
        using var context = new SGEContext();

        List<Tramite> lista = new List<Tramite>();

        foreach (var tr in context.Tramites)
        {
            Tramite t = new Tramite();
            t.Id = tr.Id;
            t.IdTramite = tr.IdTramite;
            t.IdExpediente = tr.IdExpediente;
            t.TipoTramite = tr.TipoTramite;
            t.Contenido = tr.Contenido;
            t.FechaHoraCreacion = tr.FechaHoraCreacion;
            t.FechaHoraModificacion = tr.FechaHoraModificacion;
            t.IdUsuarioUM = tr.IdUsuarioUM;
        
            lista.Add(t);
        }

        return lista;
    }

    public Tramite? GetTramite(int id)
    {
        return null;
    }

    public Tramite obtenerTramiteDelRepositorio(StreamReader sr)
    {
        return new Tramite();
    }

    public bool TramiteConsultarPorId(out Tramite? tramite, int id)
    {
        tramite = null;
        return false;
    }
}