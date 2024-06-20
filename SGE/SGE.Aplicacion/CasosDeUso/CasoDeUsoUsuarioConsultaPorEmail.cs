using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioConsultaPorEmail(IUsuarioRepositorio repoU)
{
    public Usuario? Ejecutar(string? Email){

        if (Email == null){
            return null;
        }
        return repoU.GetUsuarioPorEmail(Email);
    }
}
