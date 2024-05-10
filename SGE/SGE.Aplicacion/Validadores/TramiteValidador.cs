namespace SGE.Aplicacion;

public static class TramiteValidador
{
     public static void ValidarUsuarioTramite(Tramite tramite)
    {
        if (tramite.IdUsuarioUM <= 0) 
        {
            throw new Exception("Id de Usuario inválido");
        }
    }

    public static void ValidarContenido(Tramite tramite)
    {
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            throw new Exception("El contenido esta vacio!");
        }
    }
}
