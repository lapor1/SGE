namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaPorId(IUsuarioRepositorio repoU)
{
    public Usuario? Ejecutar(int idUsuario){

        // verificar o algo 

        return repoU.GetUsuario(idUsuario);
    }
}
