namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repoU)
{
    public bool Ejecutar(int idUsuario){

        // hacer alguna validacion (?)
        return repoU.EliminarUsuarioBaja(idUsuario);
        
    }
}
