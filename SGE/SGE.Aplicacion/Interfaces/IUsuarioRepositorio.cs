namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    public void AgregarUsuarioAlta(Usuario usuario);
    //public void AgregarUsuarioAlta(Usuario usuario);
    public bool EliminarUsuarioBaja(int idUsuario);
    bool ModificarUsuario(Usuario usuario);
    public Usuario? GetUsuario(int id);
}
