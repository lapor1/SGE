namespace SGE.Consola;
using SGE.Aplicacion;
using SGE.Repositorios;


public static class ManejoTramites
{
    public static ITramiteRepositorio repo = new RepositorioTramiteTXT();
    public static List<Tramite> tramites = new List<Tramite>();

    public static void CrearUnTramite(int idExpediente, EtiquetaTramite etiquetaTramite, string contenido, int? idUser) {
        Tramite nuevoTramite = new Tramite() {
            IdExpediente = idExpediente,
            TipoTramite = etiquetaTramite,
            Contenido = contenido,
            IdUsuarioModificacion = idUser
        };
        tramites.Add(nuevoTramite);
    }

    public static void CrearUnTramiteRandom() {
        var rand = new Random();
        Tramite nuevoTramite = new Tramite() {
            IdExpediente = rand.Next() % 10,
            TipoTramite = (EtiquetaTramite) (rand.Next() % 5),
            Contenido = rand.Next().ToString(),
            IdUsuarioModificacion = rand.Next() % 10
        };
        tramites.Add(nuevoTramite);
    }

    public static void CasoDeUsoAltaTodosLosTramitos () {
        var agregarTramiteAlta = new CasoDeUsoTramiteAlta(repo, new TramiteValidador());
        for (int i = 0; i < tramites.Count; i++) {
            try
            {
                agregarTramiteAlta.Ejecutar(tramites[i]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static void CasoDeUsoAlta (Tramite tramite) {
        var agregarTramiteAlta = new CasoDeUsoTramiteAlta(repo, new TramiteValidador());
        try
        {
            agregarTramiteAlta.Ejecutar(tramite);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ImprimirTramites () {
        var listarTramites = new CasoDeUsoListarTramites(repo);
        var lista = listarTramites.Ejecutar();
        foreach(Tramite t in lista){
            Console.WriteLine(t + "\n\n\n");
        }
    }

    public static void CasoDeUsoBaja (int id) {
        var eliminarTramiteBaja = new CasoDeUsoTramiteBaja(repo);
        eliminarTramiteBaja.Ejecutar(id);
    }

    public static void CasoDeUsoModificacionManual (int idTramite, int idExpediente, EtiquetaTramite etiquetaTramite, string contenido, int? idUser) {
        tramites[idTramite].IdTramite = idTramite + 1;
        tramites[idTramite].IdExpediente = idExpediente;
        tramites[idTramite].Contenido = contenido;
        tramites[idTramite].TipoTramite = etiquetaTramite;
        tramites[idTramite].IdUsuarioModificacion = idUser;

        var modificacionTramite = new CasoDeUsoTramiteModificacion(repo);
        modificacionTramite.Ejecutar(tramites[idTramite]);
    }

    public static void CasoDeUsoModificacion (Tramite tramite) {
        var modificacionTramite = new CasoDeUsoTramiteModificacion(repo);
        modificacionTramite.Ejecutar(tramite);
    }
}
