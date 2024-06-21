using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Excepciones;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repoU, UsuarioValidador validador)
{
    public bool Ejecutar(Usuario usuario)
    {
        if (validador.Validar(usuario, out string mensajeError))
        {
            return repoU.ModificarUsuario(usuario);
        }
        else 
        {
            throw new ValidacionException(mensajeError);
        }
    }
}
