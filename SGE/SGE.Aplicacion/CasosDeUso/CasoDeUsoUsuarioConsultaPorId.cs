using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioConsultaPorId(IUsuarioRepositorio repoU)
{
    public Usuario? Ejecutar(int idUsuario){

        // verificar o algo 

        return repoU.GetUsuario(idUsuario);
    }
}
