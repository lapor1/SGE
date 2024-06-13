namespace SGE.Aplicacion;

public class Tramite
{
    // atributos de tramites con propiedades auto-implementadas
    public int Id { get; set; }
    public int IdTramite {get; set;}
    public int IdExpediente {get; set;}
    public EtiquetaTramite TipoTramite {get; set;}
    public string? Contenido {get; set;}
    public DateTime FechaHoraCreacion {get; set;}
    public DateTime FechaHoraModificacion {get; set;}
    public int IdUsuarioUM {get; set;}

    public override string ToString() => $"Id Tramite = {IdTramite}\nId Expediente Asociado = {IdExpediente}\nTipo de Tramite = {TipoTramite}\nContenido = {Contenido}\nFecha y hora creacion = {FechaHoraCreacion:dd/MM/yy HH:mm}\nFecha y hora modificacion = {FechaHoraModificacion:dd/MM/yy HH:mm}\nId Usuario (ultima modificacion) = {IdUsuarioUM}\n";

}