using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Repositorios;

public class RepositorioUsuarioSQL : IUsuarioRepositorio
{
    public void AgregarUsuarioAlta(Usuario usuario)
    {
        using var context = new SGEContext();

        Usuario n = new Usuario();
        {
            n.IdUsuario = usuario.IdUsuario;
            n.Nombre = usuario.Nombre;
            n.Apellido = usuario.Apellido;
            n.CorreoElectrónico = usuario.CorreoElectrónico;
            n.Contraseña = usuario.Contraseña;
        }

        context.Add(n);
        context.SaveChanges();
    }

    public bool EliminarUsuarioBaja(int idUsuario)
    {
        using var context = new SGEContext();

        var usu = context.Usuario.SingleOrDefault(); //MODIFICAR

        if (usu != null)
        {
            context.Usuario.Remove(usu);
            context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ModificarUsuario(Usuario usuario)
    {
        using var context = new SGEContext();

        var modi = context.Usuarios.SingleOrDefault(); //MODIFICAR 

        if (modi != null)
        {
            foreach (var tr in context.Usuarios)
            {
                Usuario n = new Usuario();
            
                n.IdUsuario = usuario.IdUsuario;
                n.Nombre = usuario.Nombre;
                n.Apellido = usuario.Apellido;
                n.CorreoElectrónico = usuario.CorreoElectrónico;
                n.Contraseña = usuario.Contraseña;
            }

            context.SaveChanges();
            return true;
        }

        return false;
    }

    public Usuario? GetUsuario(int id)
    {
        return null;
    }
}