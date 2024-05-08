namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramiteAlta(Tramite tramite);
    List<Tramite> ListarTramites();
}
