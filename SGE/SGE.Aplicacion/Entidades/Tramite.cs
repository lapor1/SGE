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
    public int IdUsuarioModificacion {get; set;}
/*
    public Tramite () {}
    public Tramite (int idTramite, int idExpediente, EtiquetaTramite tipoTramite, string contenido, int idUsuarioModificacion) {
        IdTramite = idTramite;
        IdExpediente = idExpediente;
        TipoTramite = tipoTramite;
        Contenido = contenido;
        FechaHoraCreacion = DateTime.Now;
        FechaHoraModificacion = DateTime.Now;
        IdUsuarioModificacion = idUsuarioModificacion;
    }*/

    public override string ToString() {
        return $"Id Tramite = {IdTramite}, Contenido = {Contenido}";
    }
}
