using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repoU)
{
    public void Ejecutar(Usuario usuario){

        // hacer alguna validacion (?)
        repoU.AgregarUsuarioAlta(usuario);

    }   
}