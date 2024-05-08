namespace SGE.Aplicacion;

class Expediente
{
    public int IdTramite {get; set;}
    public string? Caratula {get; set;}
    public DateTime FechaHoraCreacion {get; set;}
    public DateTime FechaHoraModificacion {get; set;}
    public int IdUsuario {get; set;}
    public EstadoExpediente estadoExpediente {get; set;}    // [ ] falta resolver como ponerlo en mayuscula
    
    public Expediente () {}

    public Expediente (int idTramite, string caratula, int idUsuario, EstadoExpediente _estadoExpediente) {
        IdTramite = idTramite;
        Caratula = caratula;
        FechaHoraCreacion = DateTime.Now;
        FechaHoraModificacion = DateTime.Now;
        IdUsuario = idUsuario;
        estadoExpediente = _estadoExpediente;
    }
}
