using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Entidades;

//Atributos de Expediente
public class Expediente
{
    public int Id { get; set; }
    
    //public int IdExpediente {get; set;}
    public string? Caratula {get; set;}
    public DateTime FechaHoraCreacion {get; set;}
    public DateTime FechaHoraModificacion {get; set;}
    public int IdUsuarioUM {get; set;}
    public EstadoExpediente ExpedienteEstado {get; set;}

    public List<int> ListaTramites {get; set;} = new List<int>();

    public override string ToString() => $"Expediente = {Id}\nCaratula = {Caratula}\nEstado del Expediente = {ExpedienteEstado}\nFecha y hora creacion = {FechaHoraCreacion:dd/MM/yy HH:mm}\nFecha y hora modificacion = {FechaHoraModificacion:dd/MM/yy HH:mm}\nId Usuario = {IdUsuarioUM}\n";
}
