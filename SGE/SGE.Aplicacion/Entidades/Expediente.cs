namespace SGE.Aplicacion;

//Atributos de Expediente
public class Expediente
{
    public int IdExpediente {get; set;}
    public string? Caratula {get; set;}
    public DateTime FechaHoraCreacion {get; set;}
    public DateTime FechaHoraModificacion {get; set;}
    public int IdUsuarioUM {get; set;}
    public EstadoExpediente ExpedienteEstado {get; set;}

    public List<Tramite>? ListaTramites {get; set;}

    public override string ToString() => $"Expediente = {IdExpediente}\nCaratula = {Caratula}\nEstado del Expediente = {ExpedienteEstado}\nFecha y hora creacion = {FechaHoraCreacion:dd/MM/yy HH:mm}\nFecha y hora modificacion = {FechaHoraModificacion:dd/MM/yy HH:mm}\nId Usuario = {IdUsuarioUM}\n";
}
