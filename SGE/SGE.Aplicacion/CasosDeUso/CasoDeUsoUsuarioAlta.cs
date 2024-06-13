namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repoU)
{
    public void Ejecutar(Usuario usuario){

        // hacer alguna validacion (?)
        repoU.AgregarUsuarioAlta(usuario);

    }   
}