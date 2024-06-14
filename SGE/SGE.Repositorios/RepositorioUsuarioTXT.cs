using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Repositorios;

public class RepositorioUsuarioTXT : IUsuarioRepositorio
{
    readonly string _nombreArch = "usuario.txt";

    public void AgregarUsuarioAlta(Usuario usuario)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(usuario.IdUsuario);
        sw.WriteLine(usuario.Nombre);
        sw.WriteLine(usuario.Apellido);
        sw.WriteLine(usuario.CorreoElectrónico);
        sw.WriteLine(usuario.Contraseña);
        sw.WriteLine(usuario.ListaPermisos.Count);
        foreach (var p in usuario.ListaPermisos)
        {
            sw.WriteLine(p);
        }
    }

    public bool EliminarUsuarioBaja(int id)
    {
        List<Usuario> listaUsuarios = new List<Usuario>();
        listaUsuarios = listarUsuarios();
        int i = 0;
        bool encontrado = false;
        while((listaUsuarios.Count > i) && (!encontrado)) {
            if (listaUsuarios[i].IdUsuario == id) {
                listaUsuarios.Remove(listaUsuarios[i]);
                encontrado = true;
            }
            i++;
        }
        SobreEscribirArchivo(listaUsuarios);
        return encontrado;
    }

    public bool ModificarUsuario(Usuario usuario)
    {
        var listaUsuarios = new List<Usuario>();
        listaUsuarios = listarUsuarios();
        int i = 0;
        bool encontrado = false;
        while((listaUsuarios.Count > i) && (!encontrado)) {
            if (listaUsuarios[i].IdUsuario == usuario.IdUsuario) {
                listaUsuarios[i].Nombre = usuario.Nombre;
                listaUsuarios[i].Apellido = usuario.Apellido;
                listaUsuarios[i].CorreoElectrónico = usuario.CorreoElectrónico;
                listaUsuarios[i].Contraseña = usuario.Contraseña;
                listaUsuarios[i].ListaPermisos = usuario.ListaPermisos;
                encontrado = true;
            }
            i++;
        }
        SobreEscribirArchivo(listaUsuarios);
        return encontrado;
    }

    public Usuario? GetUsuario(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var usuario = obtenerUsuarioDelRepositorio(sr); 
            if (usuario.IdUsuario == id) {
                return usuario;
            }
        }
        return null;
    }

    public void SobreEscribirArchivo(List<Usuario> listaUsuarios)
    {
        using var sw = new StreamWriter(_nombreArch, false); 

        for (int i = 0; i < listaUsuarios.Count; i++)
        {
            sw.WriteLine(listaUsuarios[i].IdUsuario);
            sw.WriteLine(listaUsuarios[i].Nombre);
            sw.WriteLine(listaUsuarios[i].Apellido);
            sw.WriteLine(listaUsuarios[i].CorreoElectrónico);
            sw.WriteLine(listaUsuarios[i].Contraseña);
            sw.WriteLine(listaUsuarios[i].ListaPermisos.Count);
            foreach (var p in listaUsuarios[i].ListaPermisos)
            {
                sw.WriteLine(p);
            }
        }
    }

    public List<Usuario> listarUsuarios()
    {
        using var sw = new StreamWriter(_nombreArch, true); //Escribe archivo si no esta creado
        sw.Close();

        List<Usuario> listaUsuarios = new List<Usuario>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var usuario = obtenerUsuarioDelRepositorio(sr); 
            listaUsuarios.Add(usuario);
        }
        return listaUsuarios;
    }

    public Usuario obtenerUsuarioDelRepositorio(StreamReader sr) {
        var usuario = new Usuario();
        usuario.IdUsuario = int.Parse(sr.ReadLine() ?? "");
        usuario.Nombre = sr.ReadLine() ?? "";
        usuario.Apellido = sr.ReadLine() ?? "";
        usuario.CorreoElectrónico = sr.ReadLine() ?? "";
        usuario.Contraseña = sr.ReadLine() ?? "";
        int count = int.Parse(sr.ReadLine() ?? "");
        for(int i = 0; i < count; i++)
        {
            Permiso p = (Permiso) Enum.Parse(typeof(Permiso), sr.ReadLine() ?? "");
            usuario.ListaPermisos.Add(p);
        }  
        return usuario;
    }
}