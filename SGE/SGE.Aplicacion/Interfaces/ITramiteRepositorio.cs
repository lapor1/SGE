using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;

public interface ITramiteRepositorio
{
    void AgregarTramiteAlta(Tramite tramite);
    bool EliminarTramiteBaja(int id);
    bool ModificarTramite(Tramite tramite);
    List<Tramite> ListarTramites();
    //Tramite? GetTramite(int id);
    //Tramite obtenerTramiteDelRepositorio(StreamReader sr);
    bool TramiteConsultarPorId(out Tramite? tramite, int id);
}
