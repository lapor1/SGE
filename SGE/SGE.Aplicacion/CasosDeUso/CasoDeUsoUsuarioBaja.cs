using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repoU)
{
    public bool Ejecutar(int idUsuario){

        // hacer alguna validacion (?)
        return repoU.EliminarUsuarioBaja(idUsuario);
        
    }
}
