namespace SGE.Aplicacion;

public class Expediente
{
    public int IdExpediente {get; set;}
    public int IdTramite {get; set;}
    public string? Caratula {get; set;}
    public DateTime FechaHoraCreacion {get; set;}
    public DateTime FechaHoraModificacion {get; set;}
    public int IdUsuario {get; set;}
    public EstadoExpediente estadoExpediente {get; set;}

    public override string ToString() {
        return $"Id Expediente = {IdExpediente}\nId Tramite = {IdTramite}\nCaratula = {Caratula}\nEstado del Expediente = {estadoExpediente}\nFecha y hora creacion = {FechaHoraCreacion:dd/MM/yy HH:mm}\nFecha y hora modificacion = {FechaHoraModificacion:dd/MM/yy HH:mm}\nId Usuario = {IdUsuario}";
    }
}
