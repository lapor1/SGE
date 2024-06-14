using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repoU)
{
    public bool Ejecutar(Usuario usuario)
    {

        // validar o algo 

        return repoU.ModificarUsuario(usuario);
    }
}
