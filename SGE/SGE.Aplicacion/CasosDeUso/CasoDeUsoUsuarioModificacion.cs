using System.Runtime.InteropServices;

namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repoU)
{
    public bool Ejecutar(Usuario usuario)
    {

        // validar o algo 

        return repoU.ModificarUsuario(usuario);
    }
}
