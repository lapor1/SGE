namespace SGE.Aplicacion;

public class Tramite
{
    // atributos de tramites con propiedades auto-implementadas
    public int IdTramite {get; set;}
    public int IdExpediente {get; set;}
    public EtiquetaTramite TipoTramite {get; set;}
    public string? Contenido {get; set;}
    public DateTime FechaHoraCreacion {get; set;}
    public DateTime FechaHoraModificacion {get; set;}
    public int? IdUsuarioModificacion {get; set;}

    public override string ToString() {
        return $"Id Tramite = {IdTramite}\nId Expediente = {IdExpediente}\nTipo de Tramite = {TipoTramite}\nContenido = {Contenido}\nFecha y hora creacion = {FechaHoraCreacion:dd/MM/yy HH:mm}\nFecha y hora modificacion = {FechaHoraModificacion:dd/MM/yy HH:mm}\nId Usuario (ultima modificacion) = {IdUsuarioModificacion}";
    }

    //este SetTipoTramite lo hice con el fin de poder cambiar el estado si era necesario, porque hay
    // varios estados asi que tienen que cambiar
     public void SetTipoTramite(EtiquetaTramite nuevoEstado)
    {
        TipoTramite = nuevoEstado;
    }
}