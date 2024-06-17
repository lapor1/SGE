using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoListarUsuarios(IUsuarioRepositorio repo)
{
    public List<Usuario> Ejecutar()
    {
        //devuelve la lista de los Usuario
        return repo.ListarUsuarios();   
    }
}