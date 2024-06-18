using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore.Storage;

namespace SGE.Repositorios;

public class RepositorioTramiteSQL : ITramiteRepositorio
{

    public void AgregarTramiteAlta(Tramite tramite)
    {
        using (var DB = new SGEContext())
        { 
            DB.Tramites.Add(tramite); 
            DB.SaveChanges();
        }
    }

    public bool EliminarTramiteBaja(int id)
    {
        using (var DB = new SGEContext())
        { 
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
    }
    public bool ModificarTramite(Tramite tramite)
    {
        using (var DB = new SGEContext())
        { 
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
    }
    public List<Tramite> ListarTramites()
    {
        List<Tramite> lista = new List<Tramite>();
        using (var DB = new SGEContext())
        { 
            foreach (var t in DB.Tramites)
            {
                lista.Add(t);
            }
        }
        return lista;
    }
    
    public bool TramiteConsultarPorId(out Tramite? tramite, int id)
    {
        using (var DB = new SGEContext())
        { 
            tramite = DB.Tramites.Find(id); 
            return tramite != null;
        }
    }
}