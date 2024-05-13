namespace SGE.Aplicacion;

public class CasoDeUsoListarTramites(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar()
    {
        //devuelve la lista de los Tramites
        return repo.ListarTramites();   
    }
}