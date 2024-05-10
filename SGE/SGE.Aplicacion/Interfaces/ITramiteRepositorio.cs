using Microsoft.VisualBasic;

namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramiteAlta(Tramite tramite);
    void EliminarTramiteBaja(int id);
    void ModificarTramite(Tramite tramite);
    List<Tramite> ListarTramites();
    Tramite? GetTramite(int id);
    Tramite obtenerTramiteDelRepositorio(StreamReader sr);
    bool TramiteConsultarPorId(out Tramite tramite, int id);
    List<Tramite> TramiteConsultarListaConIdExpediente(int idExpediente);
}
