using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoListarTramites(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar()
    {
        //devuelve la lista de los Tramites
        return repo.ListarTramites();   
    }
}