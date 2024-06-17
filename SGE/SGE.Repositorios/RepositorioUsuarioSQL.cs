using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class RepositorioUsuarioSQL : IUsuarioRepositorio
{
    public SGEContext DB = new SGEContext();

    public void AgregarUsuarioAlta(Usuario usuario)
    {
        Usuario u = new Usuario();

        u.Id = usuario.Id;
        u.Nombre = usuario.Nombre;
        u.Apellido = usuario.Apellido;
        u.CorreoElectrónico = usuario.CorreoElectrónico;
        u.Contraseña = usuario.Contraseña;
        u.ListaPermisos = usuario.ListaPermisos;

        DB.Usuarios.Add(u);
        DB.SaveChanges();
    }

    public bool EliminarUsuarioBaja(int id)
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

    public bool ModificarUsuario(Usuario usuario)
    {
        var u = DB.Usuarios.Find(usuario.Id);

        if (u != null)
        {
            DB.Usuarios.Remove(u);

            u.Id = usuario.Id;
            u.Nombre = usuario.Nombre;
            u.Apellido = usuario.Apellido;
            u.CorreoElectrónico = usuario.CorreoElectrónico;
            u.Contraseña = usuario.Contraseña;
            u.ListaPermisos = usuario.ListaPermisos;

            DB.Usuarios.Add(u);

            DB.SaveChanges(true);

            return true;
        }

        return false;
    }
    
    public Usuario? GetUsuario(int id)
    {
        return DB.Usuarios.Find(id);
    }

    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> lista = new List<Usuario>();
        Usuario u = new Usuario();

        foreach (var usuario in DB.Usuarios)
        {
            u.Id = usuario.Id;
            u.Nombre = usuario.Nombre;
            u.Apellido = usuario.Apellido;
            u.CorreoElectrónico = usuario.CorreoElectrónico;
            u.Contraseña = usuario.Contraseña;
            u.ListaPermisos = usuario.ListaPermisos;
            
            lista.Add(u);
        }

        return lista;
    }
}