namespace SGE.Consola;
using SGE.Aplicacion;
using SGE.Repositorios;


public static class ManejoExpedientes
{
    public static IExpedienteRepositorio repo = new RepositorioExpedienteTXT();
    public static List<Expediente> expedientes = new List<Expediente>();

    public static void CrearUnExpediente(int _IdTramite, string _Caratula, int _IdUsuario, EstadoExpediente _estadoExpediente) {
        Expediente nuevoExpediente = new Expediente() {
            IdTramite = _IdTramite,
            Caratula = _Caratula,
            IdUsuario = _IdUsuario,
            estadoExpediente = _estadoExpediente
        };
        expedientes.Add(nuevoExpediente);
    }

    public static void CrearUnExpedienteRandom() {
        var rand = new Random();
        Expediente nuevoExpediente = new Expediente() {
            IdTramite = rand.Next() % 10,
            Caratula = rand.Next().ToString(),
            IdUsuario = rand.Next() % 10,
            estadoExpediente = (EstadoExpediente) (rand.Next() % 5)
        };
        expedientes.Add(nuevoExpediente);
    }

    public static void CasoDeUsoAltaTodosLosExpedientes () {
        var agregarExpedienteAlta = new CasoDeUsoExpedienteAlta(repo);
        for (int i = 0; i < expedientes.Count; i++) {
            agregarExpedienteAlta.Ejecutar(expedientes[i]);
        }
    }

    public static void CasoDeUsoAlta (Expediente expediente) {
        var agregarExpedienteAlta = new CasoDeUsoExpedienteAlta(repo);
        agregarExpedienteAlta.Ejecutar(expediente);
    }

    public static void ImprimirExpedientes () {
        var listarExpedientes = new CasoDeUsoListarExpedientes(repo);
        var lista = listarExpedientes.Ejecutar();
        foreach(Expediente t in lista){
            Console.WriteLine(t + "\n\n\n");
        }
    }

    public static void CasoDeUsoBaja (int id) {
        var eliminarExpedienteBaja = new CasoDeUsoExpedienteBaja(repo);
        eliminarExpedienteBaja.Ejecutar(id);
    }

    public static void CasoDeUsoModificacionManual (int _IdExpediente, int _IdTramite, string _Caratula, int _IdUsuario, EstadoExpediente _estadoExpediente) {
        expedientes[_IdExpediente].IdExpediente = _IdExpediente + 1;
        expedientes[_IdExpediente].IdTramite = _IdTramite;
        expedientes[_IdExpediente].Caratula = _Caratula;
        expedientes[_IdExpediente].IdUsuario = _IdUsuario;
        expedientes[_IdExpediente].estadoExpediente = _estadoExpediente;

        var modificacionExpediente = new CasoDeUsoExpedienteModificacion(repo);
        modificacionExpediente.Ejecutar(expedientes[_IdExpediente]);
    }

    public static void CasoDeUsoModificacion (Expediente expediente) {
        var modificacionExpediente = new CasoDeUsoExpedienteModificacion(repo);
        modificacionExpediente.Ejecutar(expediente);
    }
}
