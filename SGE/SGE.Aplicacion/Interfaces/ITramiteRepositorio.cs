using Microsoft.VisualBasic;

namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramiteAlta(Tramite tramite);
    bool EliminarTramiteBaja(int id);
    List<Tramite> ListarTramites();
    Tramite obtenerTramiteDelRepositorio(StreamReader sr);
}
