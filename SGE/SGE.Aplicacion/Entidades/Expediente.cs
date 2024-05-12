namespace SGE.Aplicacion;

public class Expediente
{
    public int IdExpediente {get; set;}
    //public int IdTramite {get; set;}  lo saco pq no entiendo si se confundió el prefe o pq hay solo un id pero se llama tramite
    public string? Caratula {get; set;}
    public DateTime FechaHoraCreacion {get; set;}
    public DateTime FechaHoraModificacion {get; set;}
    public int IdUsuarioUM {get; set;}
    public EstadoExpediente ExpedienteEstado {get; set;}

    public override string ToString() => $"Expediente = {IdExpediente}\nCaratula = {Caratula}\nEstado del Expediente = {ExpedienteEstado}\nFecha y hora creacion = {FechaHoraCreacion:dd/MM/yy HH:mm}\nFecha y hora modificacion = {FechaHoraModificacion:dd/MM/yy HH:mm}\nId Usuario = {IdUsuarioUM}";
    
}
