using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Excepciones;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repoU, UsuarioValidador validador)
{
    public void Ejecutar(Usuario usuario){

        if (validador.Validar(usuario, out string mensajeError))
        {
            repoU.AgregarUsuarioAlta(usuario);
        }
        else
        {
            throw new ValidacionException(mensajeError);
        }
    }   
}