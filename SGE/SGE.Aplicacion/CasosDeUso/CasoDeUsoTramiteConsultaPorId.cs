namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultarPorId(ITramiteRepositorio repo)
{
    public Tramite? Ejecutar(int id)
    {
        Tramite tramite= new Tramite();
        if(repo.TramiteConsultarPorId(out tramite, id))
        {
            return tramite;
        }
        return null;
    }
}