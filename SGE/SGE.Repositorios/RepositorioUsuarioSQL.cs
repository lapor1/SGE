using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class RepositorioUsuarioSQL : IUsuarioRepositorio
{
    public void AgregarUsuarioAlta(Usuario usuario)
    {
        using (var DB = new SGEContext())
        {
            DB.Usuarios.Add(usuario); 
            DB.SaveChanges();
        }
    }

    public bool EliminarUsuarioBaja(int id)
    {
        using (var DB = new SGEContext())
        { 
            var u = DB.Usuarios.Find(id);

            if (u != null)
            {
                DB.Usuarios.Remove(u);
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool ModificarUsuario(Usuario usuario)
    {
        using (var DB = new SGEContext())
        { 
            var u = DB.Usuarios.Find(usuario.Id);
            if (u != null)
            {
                DB.Usuarios.Remove(u);
                DB.Usuarios.Add(usuario);
                DB.SaveChanges();
                return true;
            }
            return false;
        }
    }
    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> lista = new List<Usuario>();
        using (var DB = new SGEContext())
        { 
            foreach (var u in DB.Usuarios)
            {
                lista.Add(u);
            }
        }
        return lista;
    }
    
    public bool UsuarioConsultarPorId(out Usuario? usuario, int id)
    {
        using (var DB = new SGEContext())
        { 
            usuario = DB.Usuarios.Find(id); 
            return usuario != null;
        }
    }

    public Usuario? GetUsuario(int id)
    {
        using (var DB = new SGEContext())
        { 
            return DB.Usuarios.Find(id);  
        }
    }
}