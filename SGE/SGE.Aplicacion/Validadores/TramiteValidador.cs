namespace SGE.Aplicacion;

public class TramiteValidador
{
    public void ValidarUsuarioTramite(Tramite tramite)
    {
        if (tramite.IdUsuarioUM <= 0) 
        {
            throw new Exception("Id de Usuario inválido");
        }
    }

    public void ValidarContenidoTramite(Tramite tramite)
    {
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new Exception("El contenido esta vacio!");
        }
    }
}
