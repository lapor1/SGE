using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Validadores;

public class UsuarioValidador
{
    public bool Validar(Usuario usuario, out string mensajeError)
    {
        mensajeError = "";
    
        if (string.IsNullOrEmpty(usuario.CorreoElectronico) )
        {
            throw new Exception("Correo Electronico vacio");
        }
        
        if (string.IsNullOrEmpty(usuario.Contraseña))
        {
            throw new Exception("Contraseña vacia");
        }

        if (string.IsNullOrEmpty(usuario.Nombre))
        {
            throw new Exception("Nombre vacio");
        }

        if (string.IsNullOrEmpty(usuario.Apellido))
        {
            throw new Exception("Apellido vacio");
        }
        return (mensajeError == "");
    }
}
